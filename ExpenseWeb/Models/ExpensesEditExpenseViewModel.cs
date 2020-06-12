using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseWeb.Models
{
    public class ExpensesEditExpenseViewModel
    {
        [Required]
        [DisplayName("Bedrag")]
        public decimal Amount { get; set; }

        [Required]
        [DisplayName("Datum")]
        public DateTime Date { get; set; }

        [MaxLength(500, ErrorMessage = "We ran out of space on our DB please accept our condolences")]
        [DisplayName("Beschrijving")]
        public string Description { get; set; }
        public int ID { get; set; }
        public string ReturnUrl { get; set; }
    }
}
