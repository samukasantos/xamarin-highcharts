using Xamarin.Forms;
using Xamarin.HighCharts.InfraStructure.DependencyService;
using Xamarin.HighCharts.Page.Interfaces;
using Xamarin.HighCharts.ViewModel;
using Xamarin.HighCharts.ViewModels.Base.Interfaces;
using Xamarin.HighCharts.ViewModels.Interfaces;
using Xamarin.HighCharts.Page.Context;

namespace Xamarin.HighCharts.Page
{
    public class LoginUserPage : ContentPage, IActionMessage
    {

        #region Constructor
        public LoginUserPage()
        {

            this.BindingContext<ILoginViewModel>();

            var layout     = new StackLayout { Padding = 10 };

            var label = new Label
            {

                Font = Font.SystemFontOfSize(NamedSize.Large),
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.Center,
                XAlign = TextAlignment.Center, // Center the text in the blue box.
                YAlign = TextAlignment.Center, // Center the text in the blue box.
            };

            layout.Children.Add(label);

            var username = new Entry { Placeholder = "Username" };
            username.SetBinding(Entry.TextProperty,  "Domain.Name");
            layout.Children.Add(username);

            var password = new Entry { Placeholder = "Password", IsPassword = true };
            password.SetBinding(Entry.TextProperty, "Domain.Password");
            layout.Children.Add(password);

            var button = new Button { Text = "Sign In", TextColor = Color.White };
            button.SetBinding(Button.CommandProperty, "LoginCommand");

            layout.Children.Add(button);
            Content = new ScrollView { Content = layout };

        }
        
        #endregion

        #region Methods

        private void Binding() 
        {
            var viewModel  = DependencyResolver.Container.GetService<ILoginViewModel>("navigation", this.Navigation);

            if(viewModel != null)
            {
                (viewModel as IViewModel).ActionMessage = this;
                BindingContext = viewModel;
            }
        }

        #endregion
    }
}
