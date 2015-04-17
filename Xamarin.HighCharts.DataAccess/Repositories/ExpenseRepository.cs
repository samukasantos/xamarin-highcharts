

using System;
using System.Collections.Generic;
using System.Linq;
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
            var user = aggregateRoot as IExpense;
            if (user == null) return null;

            return new ExpenseDatabase
            {
                Id = (aggregateRoot as EntityBase<Expense>).Id
            };
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
            var dataItems = DBContext.FindAll<ExpenseDatabase>();

            foreach (var item in dataItems)
                expenses.Add(ConvertToDomain(item));

            return expenses;
        }

        private Expense ConvertToDomain(IDatabaseModel databaseModel)
        {
            var current = databaseModel as IExpenseDatabase;
            if (current == null) return null;

            return new Expense
            {
                Id = databaseModel.Id,
                Category = current.Category,
                Date = current.Date,
                Description = current.Description,
                Value = current.Value
            };
        }

        #endregion

    }
}
