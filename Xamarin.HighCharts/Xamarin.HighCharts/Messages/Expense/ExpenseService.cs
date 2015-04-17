using System;
using Xamarin.HighCharts.Base.Messages;
using Xamarin.HighCharts.Domain.Entities;
using Newtonsoft.Json;

namespace Xamarin.HighCharts
{
	public class ExpenseService : ServiceBase,IExpenseService
	{
		
		/// <summary>
		/// Adds new expense.
		/// </summary>
		/// <returns><c>true</c>, if expense was added, <c>false</c> otherwise.</returns>
		/// <param name="expense">Expense.</param>
		public bool AddExpense (Expense expense)
		{

			return true;
		//	var json = JsonConvert.SerializeObject(expense);
		//	return Client.AddExpense(json);
		
		}




	}
}

