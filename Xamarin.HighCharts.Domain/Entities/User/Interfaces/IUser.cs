using System;

namespace Xamarin.HighCharts.Domain.Entities
{
    public interface IUser : IDomain
    {
        string Name { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        bool Transaction { get; set; }
        string UUID { get; set; }
    }
}
