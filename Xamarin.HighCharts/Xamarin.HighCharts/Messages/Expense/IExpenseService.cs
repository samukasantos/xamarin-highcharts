using System;
using Xamarin.HighCharts.Domain.Entities;

namespace Xamarin.HighCharts
{
	public interface IExpenseService
	{
		
			bool AddExpense(Expense expense);

	}
}

