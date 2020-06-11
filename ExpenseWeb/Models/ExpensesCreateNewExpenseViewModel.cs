using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseWeb.Models
{
    public class ExpensesCreateNewExpenseViewModel
    {
        [Required]
        public int Amount { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [MaxLength(500, ErrorMessage ="We ran out of space on our DB please accept our condolences")]
        public string Description { get; set; }
    }
}
