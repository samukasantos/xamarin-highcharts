
using Xamarin.HighCharts.Repository.Database.Expense.Interfaces;

namespace Xamarin.HighCharts.Repository.Database.Expense
{
    public class ExpenseComposite : ExpenseDatabase, IExpenseComposite
    {
        public string CategoryDescription { get; set; }
    }
}
