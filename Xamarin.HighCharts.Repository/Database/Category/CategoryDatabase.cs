

using SQLite.Net.Attributes;
using Xamarin.HighCharts.Repository.Database.Category.Interfaces;
using Xamarin.HighCharts.Repository.Database.Interfaces;

namespace Xamarin.HighCharts.Repository.Database.Category
{
    [Table("CATEGORY")]
    public class CategoryDatabase : IDatabaseModel, ICategoryDatabase
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
    }
}
