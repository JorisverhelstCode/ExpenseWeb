using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseWeb.Models
{
    public class StatisticsExpensesPerMonthViewModel
    {
        public int Year { get; set; }
        public List<decimal> ExpensesPerMonth { get; set; }
    }
}
