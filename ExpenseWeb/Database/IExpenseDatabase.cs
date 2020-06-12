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
        public void Insert(Expense expense);
        public Expense GetExpense(int id);
        public void DeleteExpense(int id);
    }

    public class ExpenseDatabase : IExpenseDatabase
    {
        private readonly List<Expense> _expenses;
        private int _counter;

        public ExpenseDatabase()
        {
            _expenses = new List<Expense>();
            _counter = 0;
        }

        public List<Expense> GetExpenses()
        {
            return _expenses;
        }

        public void Insert(Expense expense)
        {
            _counter++;
            expense.ID = _counter;
            _expenses.Add(expense);
        }

        public Expense GetExpense(int id)
        {
            return _expenses.FirstOrDefault(x => x.ID == id);
        }

        public void DeleteExpense(int id)
        {
            _expenses.Remove(GetExpense(id));
        }

    }
}
