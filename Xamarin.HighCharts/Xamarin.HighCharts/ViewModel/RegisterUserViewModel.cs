using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.HighCharts.Domain;
using Xamarin.HighCharts.Messages;
using Xamarin.HighCharts.Page;

namespace Xamarin.HighCharts.ViewModel
{
    public class RegisterUserViewModel : BaseViewModel
    {
        private INavigation navigation;
        public RegisterUserViewModel(INavigation navigation)
        {
            this.navigation = navigation;
        }
        public const string EmailPropertyName = "Email";
        private string email = string.Empty;
        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value, EmailPropertyName); }
        }

        public const string PasswordPropertyName = "Password";
        private string password = string.Empty;
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value, PasswordPropertyName); }
        }

        public const string NamePropertyName = "Name";
        private string name = string.Empty;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value, NamePropertyName); }
        }

        private Command loginCommand;
        public const string LoginCommandPropertyName = "LoginCommand";
        public Command LoginCommand
        {
            get
            {
                return loginCommand ?? (loginCommand = new Command(async () => await ExecuteLoginCommand()));
            }
        }

        protected async Task ExecuteLoginCommand()
        {
            ServiceRequestBase service = new ServiceRequestBase();
            User user = new User();
            user.Email = Email;
            user.Name = Name;
            user.Password = Password;
            bool userOK = service.AddUser(user);

          
            
          
        }
    }
}
