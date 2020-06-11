using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseWeb.Domain
{
    public class Expense
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }
    }
}
