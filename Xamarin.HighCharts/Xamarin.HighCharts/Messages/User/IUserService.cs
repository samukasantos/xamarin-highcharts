

using Xamarin.HighCharts.Domain.Entities;

namespace Xamarin.HighCharts.Messages
{
    public interface IUserService
    {
        bool AddUser(User user);
        bool ValidateUser(string login, string password);
    }
}
