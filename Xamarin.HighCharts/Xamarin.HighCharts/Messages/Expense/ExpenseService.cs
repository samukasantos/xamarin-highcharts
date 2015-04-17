using System;
using Xamarin.HighCharts.Base.Messages;
using Xamarin.HighCharts.Domain.Entities;
using Newtonsoft.Json;

namespace Xamarin.HighCharts
{
	public class ExpenseService : ServiceBase,IExpenseService
	{
        private class ExpensiveProxy
        {
            public int Id { get; set; }
            public string Description { get; set; }
            public string Value { get; set; }
            public string Date { get; set; }
            public int Category { get; set; }
        }

		
		/// <summary>
		/// Adds new expense.
		/// </summary>
		/// <returns><c>true</c>, if expense was added, <c>false</c> otherwise.</returns>
		/// <param name="expense">Expense.</param>
		public bool AddExpense (Expense expense)
		{
             try
            {
                var json = JsonConvert.SerializeObject
                    (
                        new ExpensiveProxy
                        {
                            Id          = expense.Id,
                            Description = expense.Description,
                            Value       = expense.Value,
                            Category    = expense.Category.Id,
                            Date        = expense.Date.ToString()
                        }
                    );
                Client.AddExpenseAsync(json);

                return true;
            }
            catch (Exception operationException)
            {
                CurrentException = operationException;
                return false;
           } 
		}

	}

    
}

