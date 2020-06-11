using ExpenseWeb.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseWeb.Database
{
    public interface IExpenseDatabase
    {
        public List<Expense> GetExpenses();
    }

    public class ExpenseDatabase : IExpenseDatabase
    {
        private readonly List<Expense> _expenses;

        public ExpenseDatabase()
        {
            _expenses = new List<Expense>();
        }

        public List<Expense> GetExpenses()
        {
            return _expenses;
        }
    }
}
