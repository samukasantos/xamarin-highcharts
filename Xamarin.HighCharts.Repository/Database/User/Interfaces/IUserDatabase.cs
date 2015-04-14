using System;

namespace Xamarin.HighCharts.Repository.Database.User.Interfaces
{
    public interface IUserDatabase
    {
        string Email { get; set; }
        string Name { get; set; }
        string Password { get; set; }
        bool Transaction { get; set; }
    }
}
