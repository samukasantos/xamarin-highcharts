
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.HighCharts.DataAccess.Repositories;
using Xamarin.HighCharts.Domain;
using Xamarin.HighCharts.Domain.Interfaces;
using Xamarin.HighCharts.InfraStructure.DependencyService;
using Xamarin.HighCharts.InfraStructure.DependencyService.Enumerators;
using Xamarin.HighCharts.InfraStructure.DependencyService.Interfaces;
using Xamarin.HighCharts.InfraStructure.UnitWork;
using Xamarin.HighCharts.Messages;
using Xamarin.HighCharts.Messages.Base;
using Xamarin.HighCharts.Page;
using Xamarin.HighCharts.Repository;
using Xamarin.HighCharts.Repository.Context;
using Xamarin.HighCharts.Repository.Context.Interface;
using Xamarin.HighCharts.Repository.Database.User;
using Xamarin.HighCharts.Repository.Database.User.Interfaces;
using Xamarin.HighCharts.ViewModel;
using Xamarin.HighCharts.ViewModels;
using Xamarin.HighCharts.ViewModels.Interfaces;
using Xamarin.HighCharts.WCFHighChartsService;

namespace Xamarin.HighCharts
{
    public class App : Application, IDependencyContainerService
    {

        #region Constructor

        public App()
        {
            ContainerStart();

            MainPage = new LoginUserPage();
        }

        #endregion

        #region IDependencyContainerService members

        public virtual IList<IDependencyObject> InjectDependencies()
        {
            return new List<IDependencyObject> 
            {
                new DependencyObject(typeof(IUser), typeof(User), LifetimeType.Transient),
                new DependencyObject(typeof(IUserRepository), typeof(UserRepository), LifetimeType.Transient),
                new DependencyObject(typeof(IUserDatabase), typeof(UserDatabase), LifetimeType.Transient),
                new DependencyObject(typeof(IDBContext), typeof(DBContext<SQLite.Net.SQLiteConnection>)),
                new DependencyObject(typeof(IUserService), typeof(UserService)),
                new DependencyObject(typeof(IRegisterUserViewModel), typeof(RegisterUserViewModel), LifetimeType.Transient, null, null, new object[]{ typeof(INavigation) }),
                new DependencyObject(typeof(ILoginViewModel), typeof(LoginViewModel), LifetimeType.Transient, null, null, new object[]{ typeof(INavigation) }),
                new DependencyObject(typeof(IContext<SQLite.Net.SQLiteConnection>), DependencyService.Get<IContext<SQLite.Net.SQLiteConnection>>()),
                new DependencyObject(typeof(IUnitWork), typeof(UnitWork))
            };
        }

        public virtual void ContainerStart()
        {
            DependencyResolver.Container.UnityInjection(DependencyContainerFactory.GetContainer(InjectDependencies()));
        }
        #endregion
    }
}
