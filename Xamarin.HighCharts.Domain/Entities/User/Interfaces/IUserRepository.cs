

using System.Collections.Generic;
using Xamarin.HighCharts.InfraStructure.Domain.Interfaces;

namespace Xamarin.HighCharts.Domain.Entities
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> FindAll();

        User FindByToken(string token);
    }
}
