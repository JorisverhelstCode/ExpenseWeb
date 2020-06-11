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

        public IActionResult D()
        {
            return View();
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