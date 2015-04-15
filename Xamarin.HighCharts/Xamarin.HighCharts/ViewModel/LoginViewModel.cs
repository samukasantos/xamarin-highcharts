using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.HighCharts.Messages;

namespace Xamarin.HighCharts.ViewModel
{


    public class LoginViewModel : BaseViewModel
    {
        private INavigation navigation;
        public LoginViewModel(INavigation navigation)
        {
            this.navigation = navigation;
        }
        public const string UsernamePropertyName = "Username";
        private string username = string.Empty;
        public string Username
        {
            get { return username; }
            set { SetProperty(ref username, value, UsernamePropertyName); }
        }

        public const string PasswordPropertyName = "Password";
        private string password = string.Empty;
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value, PasswordPropertyName); }
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
            bool userOK = service.ValidateUser(Username, Password);
            Debug.WriteLine(username);
            Debug.WriteLine(password);
        }
    }
}
