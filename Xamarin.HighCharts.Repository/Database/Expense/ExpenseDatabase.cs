
using SQLite.Net.Attributes;
using Xamarin.HighCharts.Repository.Database.Expense.Interfaces;
using Xamarin.HighCharts.Repository.Database.Interfaces;

namespace Xamarin.HighCharts.Repository.Database.Expense
{
    [Table("EXPENSE")]
    public class ExpenseDatabase : IDatabaseModel, IExpenseDatabase
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(150)]
        public string Description { get; set; }
        public int Category { get; set; }
        [MaxLength(30)]
        public string Date { get; set; }
        [MaxLength(15)]
        public string Value { get; set; }
        [MaxLength(30)]
        public string UUID { get; set; }
    }
}
