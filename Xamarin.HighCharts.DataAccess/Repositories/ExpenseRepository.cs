

using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Highcharts.Domain.ValueObjects;
using Xamarin.HighCharts.Domain.Entities;
using Xamarin.HighCharts.InfraStructure.Domain;
using Xamarin.HighCharts.InfraStructure.Domain.Interfaces;
using Xamarin.HighCharts.Repository;
using Xamarin.HighCharts.Repository.Database.Expense;
using Xamarin.HighCharts.Repository.Database.Expense.Interfaces;
using Xamarin.HighCharts.Repository.Database.Interfaces;

namespace Xamarin.HighCharts.DataAccess.Repositories
{
    public class ExpenseRepository : Repository<Expense, ExpenseDatabase>, IExpenseRepository
    {
        #region Methods

        public override IDatabaseModel ConvertToDatabaseType(IAggregateRoot aggregateRoot)
        {
            var expense = aggregateRoot as IExpense;
            if (expense == null) return null;

            var expenseDB = new ExpenseDatabase
            {
                Id = (aggregateRoot as EntityBase<Expense>).Id,
                Date =  expense.Date.ToString(),
                Value = expense.Value,
                Description = expense.Description,
                Category = expense.Category.Id
            };
            expenseDB.UUID = expense.UUID;
            return expenseDB;
        }

        public override Expense FindByToken(string id)
        {
            return FindAll().FirstOrDefault(c => c.UUID == id);
        }

        public Expense FindById(int id)
        {
            return FindAll().FirstOrDefault(c => c.Id == id);
        }
        #endregion

        #region IExpenseRepository members
        public IEnumerable<Expense> FindAll()
        {
            var expenses = new List<Expense>();

            var dataItems = DBContext.ExecuteCrossQuery<ExpenseComposite>
                (
                    @"SELECT EXPENSE.Id as Id, " +
                    "        EXPENSE.Description as Description "+
                    "        EXPENSE.Category as Category " +
                    "        EXPENSE.Date as Date " +
                    "        EXPENSE.Value as Value " +
                    "        EXPENSE.UUID as UUID " +
                    "        CATEGORY.Description as CategoryDescription" +
                    " FROM EXPENSE " +
                    "   INNER JOIN CATEGORY " +
                    "   ON EXPENSE.CATEGORY = CATEGORY.ID ",
                    new object[] { }
                );
                
            foreach (var item in dataItems)
                expenses.Add(ConvertToDomain(item));

            return expenses;
        }


        private Expense ConvertToDomain(IDatabaseModel databaseModel)
        {
            var current = databaseModel as IExpenseComposite;
            if (current == null) return null;

            var expense = new Expense
            {
                Id = databaseModel.Id,
                Category = new Category 
                    {
                        Id = current.Category,
                        Description = current.CategoryDescription
                    },
                Date = Convert.ToDateTime(current.Date),
                Description = current.Description,
                Value = current.Value
            };
            expense.UUID = current.UUID;
            return expense;
        }

        #endregion

    }
}
