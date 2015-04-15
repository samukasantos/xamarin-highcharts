using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.HighCharts.Domain;
using Xamarin.HighCharts.InfraStructure.DependencyService;
using Xamarin.HighCharts.Messages;
using Xamarin.HighCharts.Page;
using Xamarin.HighCharts.ViewModels.Base;
using Xamarin.HighCharts.ViewModels.Interfaces;

namespace Xamarin.HighCharts.ViewModel
{
    public class RegisterUserViewModel : ViewModelBase<User>, IRegisterUserViewModel
    {

        #region Fields

        private User _user;
        private Command _loginCommand;

        #endregion

        #region Properties

        public override User Domain
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
                RaisedPropertyChanged(() => Domain);
            }
        }

        #endregion

        #region Constructor

        public RegisterUserViewModel(INavigation navigation)
            :base(navigation)
        {

        }

        #endregion

        #region Commands
        
        public Command LoginCommand
        {
            get
            {
                return _loginCommand ?? (_loginCommand = new Command(async () => await ExecuteLoginCommand()));
            }
        }
        
        #endregion

        #region Methods

        protected async Task ExecuteLoginCommand()
        {
            var userService = DependencyResolver.Container.GetService<IUserService>();
            var result      = userService.AddUser(Domain);
        } 

        #endregion
    }
}
