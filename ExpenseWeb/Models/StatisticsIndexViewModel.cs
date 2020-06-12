using ExpenseWeb.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseWeb.Models
{
    public class StatisticsIndexViewModel
    {
        public Expense Highest { get; set; }
        public Expense Lowest { get; set; }
        public DateTime MostSpendDay { get; set; }
        public decimal MostSpendAmount { get; set; }
    }
}
