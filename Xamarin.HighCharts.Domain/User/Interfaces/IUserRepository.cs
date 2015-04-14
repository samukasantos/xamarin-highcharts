

using System.Collections.Generic;
using Xamarin.HighCharts.InfraStructure.Domain.Interfaces;

namespace Xamarin.HighCharts.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User, int>
    {
        IEnumerable<User> FindAll();
    }
}
