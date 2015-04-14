
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.HighCharts.Common.DependencyService;
using Xamarin.HighCharts.Common.DependencyService.Enumerators;
using Xamarin.HighCharts.Common.DependencyService.Interfaces;
using Xamarin.HighCharts.DataAccess.Repositories;
using Xamarin.HighCharts.Domain;
using Xamarin.HighCharts.Domain.Interfaces;
using Xamarin.HighCharts.Repository.Context;
using Xamarin.HighCharts.Repository.Context.Interface;
using Xamarin.HighCharts.Repository.Database.User;
using Xamarin.HighCharts.Repository.Database.User.Interfaces;

namespace Xamarin.HighCharts
{
    public class App : Application, IDependencyContainerService
    {

        #region IDependencyContainerService members
        public virtual void ContainerStart()
        {
            throw new System.NotImplementedException();
        }

        public virtual IList<IDependencyObject> SetDependencies()
        {
            return new List<IDependencyObject> 
            {
                new DependencyObject(typeof(IUser), typeof(User), LifetimeType.Transient),
                new DependencyObject(typeof(IUserRepository), typeof(RepositoryUser), LifetimeType.Transient),
                new DependencyObject(typeof(IUserDatabase), typeof(UserDatabase), LifetimeType.Transient),
                new DependencyObject(typeof(IDBContext), typeof(DBContext<SQLite.Net.SQLiteConnection> ))
               
            };
        } 
        #endregion
    }
}
