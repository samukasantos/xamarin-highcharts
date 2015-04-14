
using Xamarin.HighCharts.Repository.Database.Interfaces;
using Xamarin.HighCharts.Repository.Database.User.Interfaces;

namespace Xamarin.HighCharts.Repository.Database.User
{
    public class UserDatabase : IDatabaseModel, IUserDatabase
    {
        public int Id           { get; set; }
        public string Name      { get; set; }
        public string Email     { get; set; }
        public string Password  { get; set; }
        public bool Transaction { get; set; }
    }
}
