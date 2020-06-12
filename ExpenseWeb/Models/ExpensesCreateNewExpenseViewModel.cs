using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseWeb.Models
{
    public class ExpensesCreateNewExpenseViewModel
    {
        [Required]
        [DisplayName("Bedrag")]
        public decimal Amount { get; set; }

        [Required]
        [DisplayName("Datum")]
        public DateTime Date { get; set; }

        [DisplayName("Beschrijving")]
        [MaxLength(500, ErrorMessage ="We ran out of space on our DB please accept our condolences")]
        public string Description { get; set; }
    }
}
