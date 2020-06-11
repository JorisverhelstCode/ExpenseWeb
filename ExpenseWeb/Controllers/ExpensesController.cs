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

        public ExpensesController(ExpenseDatabase db)
        {
            _expensesDB = db;
        }

        public IActionResult Index()
        {
            return View(CreateExpensesList());
        }

        public IActionResult CreateNewExpense()
        {
            ExpensesCreateNewExpenseViewModel ecnevm = new ExpensesCreateNewExpenseViewModel();
            ecnevm.Date = DateTime.Now;
            return View(ecnevm);
        }

        [HttpPost]
        public IActionResult CreateNewExpense(ExpensesCreateNewExpenseViewModel model)
        {
            if (!TryValidateModel(model))
            {
                return View(model);
            }


            return RedirectToAction("Index");
        }

        public List<ExpensesIndexViewModel> CreateExpensesList()
        {
            List<Expense> expensesFromDB = _expensesDB.GetExpenses();
            List<ExpensesIndexViewModel> expensesInList = new List<ExpensesIndexViewModel>();
            foreach (var expense in expensesFromDB)
            {
                expensesInList.Add(new ExpensesIndexViewModel
                {
                    Amount = expense.Amount,
                    Date = expense.Date
                });
            }

            return expensesInList;
        }
    }
}