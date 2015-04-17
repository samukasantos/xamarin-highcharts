using System.Collections.Generic;
using Xamarin.HighCharts.InfraStructure.Domain.Interfaces;

namespace Xamarin.HighCharts.Domain.Entities
{
	public interface IExpenseRepository : IRepository<Expense>
    {
        IEnumerable<Expense> FindAll();

        Expense FindByToken(string token);
    }
}
