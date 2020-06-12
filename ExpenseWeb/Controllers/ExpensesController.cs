using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseWeb.Database;
using ExpenseWeb.Domain;
using ExpenseWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseWeb.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly IExpenseDatabase _expensesDB;

        public ExpensesController(IExpenseDatabase db)
        {
            _expensesDB = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(CreateExpensesList());
        }

        [HttpGet]
        public IActionResult CreateNewExpense()
        {
            ExpensesCreateNewExpenseViewModel ecnevm = new ExpensesCreateNewExpenseViewModel();
            ecnevm.Date = DateTime.Now;
            return View(ecnevm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateNewExpense(ExpensesCreateNewExpenseViewModel model)
        {
            if (!TryValidateModel(model))
            {
                return View(model);
            }

            Expense expense = new Expense
            {
                Amount = model.Amount,
                Date = model.Date,
                Description = model.Description
            };

            _expensesDB.Insert(expense);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult DeleteExpense(int id, string returnUrl)
        {
            Expense expenseFromDb = _expensesDB.GetExpense(id);
            ExpensesDeleteExpenseViewModel edevm = new ExpensesDeleteExpenseViewModel
            {
                Amount = expenseFromDb.Amount,
                Date = expenseFromDb.Date,
                Description = expenseFromDb.Description,
                ID = id,
                ReturnUrl = returnUrl
            };

            return View(edevm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteExpense(ExpensesDeleteExpenseViewModel model)
        {
            _expensesDB.DeleteExpense(model.ID);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult EditExpense(int id, string returnUrl)
        {
            Expense expenseFromDb = _expensesDB.GetExpense(id);
            ExpensesEditExpenseViewModel eeevm = new ExpensesEditExpenseViewModel
            {
                Amount = expenseFromDb.Amount,
                Date = expenseFromDb.Date,
                Description = expenseFromDb.Description,
                ID = id,
                ReturnUrl = returnUrl
            };

            return View(eeevm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditExpense(ExpensesEditExpenseViewModel model)
        {
            if (!TryValidateModel(model))
            {
                return View(model);
            }

            Expense expense = new Expense
            {
                Amount = model.Amount,
                Date = model.Date,
                Description = model.Description
            };

            _expensesDB.Update(model.ID, expense);
            return RedirectToAction(model.ReturnUrl);
        }

        [HttpGet]
        public IActionResult ExpenseDetails(int id)
        {
            Expense expenseFromDb = _expensesDB.GetExpense(id);
            ExpensesExpenseDetailsViewModel eedvm = new ExpensesExpenseDetailsViewModel
            {
                Amount = expenseFromDb.Amount,
                Date = expenseFromDb.Date,
                Description = expenseFromDb.Description,
                ID = id
            };

            return View(eedvm);
        }

        public List<ExpensesIndexViewModel> CreateExpensesList()
        {
            List<Expense> expensesFromDB = _expensesDB.GetExpenses();
            List<ExpensesIndexViewModel> expensesInList = new List<ExpensesIndexViewModel>();
            if (expensesFromDB.Count != 0)
            {
                for (int i = 0; i < expensesFromDB.Count; i++)
                {
                    Expense expense = expensesFromDB.ElementAt(i);
                    ExpensesIndexViewModel expenseModel = new ExpensesIndexViewModel
                    {
                        Amount = expense.Amount,
                        Date = expense.Date,
                        ID = expense.ID
                    };
                    bool Added = false;
                    if (i != 0)
                    {
                        int count = expensesInList.Count;
                        for (int j = 0; j < count; j++)
                        {
                            if ((expenseModel.Date < expensesInList.ElementAt(j).Date) && !Added)
                            {
                                expensesInList.Insert(j, expenseModel);
                                Added = true;
                            }
                            else
                            {
                                if ((j == (count - 1)) && !Added)
                                {
                                    expensesInList.Add(expenseModel);
                                    Added = true;
                                }
                            }
                        }
                    } else
                    {
                        expensesInList.Add(expenseModel);
                    }
                }
            }
            return expensesInList;
        }
    }
}