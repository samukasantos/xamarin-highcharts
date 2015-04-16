using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.HighCharts.Domain;
using Xamarin.HighCharts.Domain.Interfaces;
using Xamarin.HighCharts.InfraStructure.DependencyService;
using Xamarin.HighCharts.InfraStructure.UnitWork;
using Xamarin.HighCharts.Messages;
using Xamarin.HighCharts.Page;
using Xamarin.HighCharts.ViewModels.Base;
using Xamarin.HighCharts.ViewModels.Base.Interfaces;
using Xamarin.HighCharts.ViewModels.Interfaces;

namespace Xamarin.HighCharts.ViewModel
{
    public class RegisterUserViewModel : ViewModelBase<User>, IRegisterUserViewModel, IUserRepositoryService
    {
        #region Fields

        private User _user;
        private Command _saveCommand;

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


        public IUserRepository Repository
        {
            get { return DependencyResolver.Container.GetService<IUserRepository>(); }
        }

        public IUnitWork UnitWork
        {
            get { return DependencyResolver.Container.GetService<IUnitWork>(); }
        }

        #endregion

        #region Constructor

        public RegisterUserViewModel(INavigation navigation)
            : base(navigation) { }

        #endregion

        #region Commands
        
        public Command SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand = new Command(async () => await SaveUserCommand()));
            }
        }
        
        #endregion

        #region Methods

        protected async Task SaveUserCommand()
        {
            var userService = DependencyResolver.Container.GetService<IUserService>();

            try
            {
                ThrowExceptionIfInvalidDomain(Domain);

                //Service
                var result = userService.AddUser(Domain);

                if (result)
                {
                    //Database
                    Repository.Save(Domain);
                    UnitWork.Commit();

                    //TODO .: Use internationalization for messages. 
                    await ActionMessage.DisplayAlert("Success", "User registered successfully.", "Ok");
                }
                else
                {
                    await ActionMessage.DisplayAlert("Fail", "Service error.", "Ok");
                }
            }
            catch (Exception invalidDomainException)
            {
                ActionMessage.DisplayAlert("Error", invalidDomainException.Message, "Ok");
            }
        }

        public override void ThrowExceptionIfInvalidDomain(User domain)
        {
            var rules = domain.GetBrokenRules( c => c.Email, c => c.Password, c => c.Name);
            if (rules.Any()) 
            {
                foreach (var rule in rules)
                    throw new Exception(rule.DescriptionRule);
            }
        }

        #endregion
       
    }
}
