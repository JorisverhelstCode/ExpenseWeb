﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseWeb.Models
{
    public class ExpensesIndexViewModel
    {
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public int ID { get; set; }
    }
}
