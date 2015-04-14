

using System.Collections.Generic;
using xamarin.highcharts.infrastructure.Domain.Interfaces;

namespace xamarin.highcharts.domain.Interface
{
    public interface IUserRepository : IRepository<User, int>
    {
        IEnumerable<User> FindAll();
    }
}
