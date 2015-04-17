

namespace Xamarin.HighCharts.Repository.Database.Expense.Interfaces
{
    public interface IExpenseComposite : IExpenseDatabase
    {
        string CategoryDescription { get; set; }
    }
}
