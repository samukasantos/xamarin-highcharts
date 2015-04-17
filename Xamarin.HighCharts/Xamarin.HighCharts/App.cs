
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Highcharts.Domain.ValueObjects;
using Xamarin.HighCharts.DataAccess.Repositories;
using Xamarin.HighCharts.Domain.Entities;
using Xamarin.HighCharts.Domain.ValueObjects;
using Xamarin.HighCharts.InfraStructure.DependencyService;
using Xamarin.HighCharts.InfraStructure.DependencyService.Enumerators;
using Xamarin.HighCharts.InfraStructure.DependencyService.Interfaces;
using Xamarin.HighCharts.InfraStructure.UnitWork;
using Xamarin.HighCharts.Messages;
using Xamarin.HighCharts.Page;
using Xamarin.HighCharts.Repository;
using Xamarin.HighCharts.Repository.Context;
using Xamarin.HighCharts.Repository.Context.Interface;
using Xamarin.HighCharts.Repository.Database.Category;
using Xamarin.HighCharts.Repository.Database.Category.Interfaces;
using Xamarin.HighCharts.Repository.Database.Interfaces;
using Xamarin.HighCharts.Repository.Database.User;
using Xamarin.HighCharts.Repository.Database.User.Interfaces;
using Xamarin.HighCharts.ViewModel;
using Xamarin.HighCharts.ViewModels;
using Xamarin.HighCharts.ViewModels.Interfaces;

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
                new DependencyObject(typeof(ICategory), typeof(Category), LifetimeType.Transient),
                new DependencyObject(typeof(IUserRepository), typeof(UserRepository), LifetimeType.Transient),
                new DependencyObject(typeof(IValueObjectRepository<Category>), typeof(ValueObjectRepository<Category, CategoryDatabase>), LifetimeType.Transient),
                new DependencyObject(typeof(IUserDatabase), typeof(UserDatabase), LifetimeType.Transient),
                new DependencyObject(typeof(ICategoryDatabase), typeof(CategoryDatabase), LifetimeType.Transient),
                new DependencyObject(typeof(IDBContext), typeof(DBContext<SQLite.Net.SQLiteConnection>)),
                new DependencyObject(typeof(IUserService), typeof(UserService)),
                new DependencyObject(typeof(ICategoryService), typeof(CategoryService)),
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
