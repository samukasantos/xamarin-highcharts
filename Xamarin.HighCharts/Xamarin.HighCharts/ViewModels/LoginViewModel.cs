using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.HighCharts.Domain;
using Xamarin.HighCharts.InfraStructure.DependencyService;
using Xamarin.HighCharts.Messages;
using Xamarin.HighCharts.ViewModels.Base;
using Xamarin.HighCharts.ViewModels.Interfaces;
using System.Linq;
using System.Linq.Expressions;
using Xamarin.HighCharts.Page;

namespace Xamarin.HighCharts.ViewModels
{

    public class LoginViewModel : ViewModelBase<User>, ILoginViewModel
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

        public LoginViewModel(INavigation navigation)
            : base(navigation)
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

            try
            {
                ThrowExceptionIfInvalidDomain(Domain);
               
                var result = userService.ValidateUser(Domain.Name, Domain.Password);

                if (result) 
                {
                  await  Navigation.PushAsync(new RootPage());
                }
            }
            catch (Exception invalidDomainException)
            {
                ActionMessage.DisplayAlert("Error", invalidDomainException.Message, "Ok");
            }
        }

        public override void ThrowExceptionIfInvalidDomain(User domain)
        {
            var rules = domain.GetBrokenRules( c => c.Name, c => c.Password);
            if (rules.Any())
            {
                foreach (var rule in rules)
                    throw new Exception(rule.DescriptionRule);
            }
        }
        #endregion



       
    }
}
