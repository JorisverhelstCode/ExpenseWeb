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
        public Expense GetHighest();
        public Expense GetLowest();
        public DateTime GetMostSpendDay();
        public decimal GetMostSpendAmount();
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

        public Expense GetHighest()
        {
            if (_expenses.Count == 0)
            {
                return null;
            }

            Expense highest = _expenses.ElementAt(0);
            foreach (var expense in _expenses)
            {
                if (expense.Amount > highest.Amount)
                {
                    highest = expense;
                }
            }
            return highest;
        }

        public Expense GetLowest()
        {
            if (_expenses.Count == 0)
            {
                return null;
            }

            Expense lowest = _expenses.ElementAt(0);
            foreach (var expense in _expenses)
            {
                if (expense.Amount < lowest.Amount)
                {
                    lowest = expense;
                }
            }
            return lowest;
        }

        public DateTime GetMostSpendDay()
        {
            var groupedByDate = _expenses.GroupBy(x => x.Date.Date);
            var sumPerDay = new Dictionary<DateTime, decimal>();
            foreach (var day in groupedByDate)
            {
                var sumFromDay = day.ToList().Sum(x => x.Amount);
                sumPerDay.Add(day.Key, sumFromDay);
            }
            return sumPerDay.OrderByDescending(x => x.Value).First().Key;
        }

        public decimal GetMostSpendAmount()
        {
            var groupedByDate = _expenses.GroupBy(x => x.Date.Date);
            var sumPerDay = new Dictionary<DateTime, decimal>();
            foreach (var day in groupedByDate)
            {
                var sumFromDay = day.ToList().Sum(x => x.Amount);
                sumPerDay.Add(day.Key, sumFromDay);
            }
            return sumPerDay.OrderByDescending(x => x.Value).First().Value;
        }
    }
}
