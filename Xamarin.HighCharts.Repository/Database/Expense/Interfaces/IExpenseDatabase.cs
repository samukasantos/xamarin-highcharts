
namespace Xamarin.HighCharts.Repository.Database.Expense.Interfaces
{
    public interface IExpenseDatabase
    {
        string Description { get; set; }
        int Category { get; set; }
        string Date { get; set; }
        string Value { get; set; }
        string UUID { get; set; }
    }
}
