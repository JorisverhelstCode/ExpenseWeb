using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseWeb.Database;
using ExpenseWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseWeb.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IExpenseDatabase _expensesDB;

        public StatisticsController(IExpenseDatabase db)
        {
            _expensesDB = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            StatisticsIndexViewModel sivm = new StatisticsIndexViewModel
            {
                Highest = _expensesDB.GetHighest(),
                Lowest = _expensesDB.GetLowest(),
                MostSpendDay = _expensesDB.GetMostSpendDay(),
                MostSpendAmount = _expensesDB.GetMostSpendAmount()
            };
            return View(sivm);
        }

        [HttpGet]
        public IActionResult ExpensesPerMonth(int year)
        {
            return View();
        }
    }
}