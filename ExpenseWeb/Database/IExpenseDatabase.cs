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
        public void Update(int id, Expense expense);
    }

    public class ExpenseDatabase : IExpenseDatabase
    {
        private readonly List<Expense> _expenses;
        private int _counter;

        public ExpenseDatabase()
        {
            _expenses = new List<Expense>();
            _counter = 0;
            FillListWithRandomExpenses();
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

        public void Update(int id, Expense expense)
        {
            Expense toBeUpdatedExpense = GetExpense(id);
            toBeUpdatedExpense.Amount = expense.Amount;
            toBeUpdatedExpense.Date = expense.Date;
            toBeUpdatedExpense.Description = expense.Description;
        }

        public void FillListWithRandomExpenses()
        {
            Insert(new Expense
            {
                Amount = 1,
                Date = DateTime.Now,
                Description = "test1"
            });

            Insert(new Expense
            {
                Amount = 2,
                Date = new DateTime(2003, 03, 15),
                Description = "test2"
            });

            Insert(new Expense
            {
                Amount = 3,
                Date = new DateTime(1995, 06, 3),
                Description = "test3"
            });

            Insert(new Expense
            {
                Amount = 4,
                Date = new DateTime(2000, 01, 28),
                Description = "test4"
            });
        }
    }
}
