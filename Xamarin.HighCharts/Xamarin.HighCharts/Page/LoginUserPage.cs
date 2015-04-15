using Xamarin.Forms;
using Xamarin.HighCharts.InfraStructure.DependencyService;
using Xamarin.HighCharts.ViewModel;
using Xamarin.HighCharts.ViewModels.Interfaces;

namespace Xamarin.HighCharts.Page
{
    public class LoginUserPage : ContentPage
    {

        #region Constructor
        public LoginUserPage()
        {
            BindingContext = DependencyResolver.Container.GetService<ILoginViewModel>("navigation", this.Navigation);
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
            username.SetBinding(Entry.TextProperty,  "Name");
            layout.Children.Add(username);

            var password = new Entry { Placeholder = "Password", IsPassword = true };
            password.SetBinding(Entry.TextProperty, "Password");
            layout.Children.Add(password);

            var button = new Button { Text = "Sign In", TextColor = Color.White };
            button.SetBinding(Button.CommandProperty, "LoginCommand");

            layout.Children.Add(button);
            Content = new ScrollView { Content = layout };
        }
        
        #endregion
    }
}
