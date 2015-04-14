
using SQLite.Net.Attributes;
using Xamarin.HighCharts.Repository.Database.Interfaces;
using Xamarin.HighCharts.Repository.Database.User.Interfaces;

namespace Xamarin.HighCharts.Repository.Database.User
{
    [Table("USER")]
    public class UserDatabase : IDatabaseModel, IUserDatabase
    {
        [PrimaryKey, AutoIncrement]
        public int Id           { get; set; }
        [MaxLength(100)]
        public string Name      { get; set; }
        [MaxLength(100)]
        public string Email     { get; set; }
        [MaxLength(15)]
        public string Password  { get; set; }
        public bool Transaction { get; set; }
    }
}
