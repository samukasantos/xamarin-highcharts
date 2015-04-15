using Xamarin.Forms;
using Xamarin.HighCharts.ViewModel;
using Xamarin.HighCharts.InfraStructure.DependencyService;
using Xamarin.HighCharts.ViewModels.Interfaces;

namespace Xamarin.HighCharts.Page
{
    public class RegisterUserPage : ContentPage
    {
        #region Constructor
        public RegisterUserPage()
        {
            BindingContext = DependencyResolver.Container.GetService<IRegisterUserViewModel>("navigation", this.Navigation);
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

            var email = new Entry { Placeholder = "Email" };
            email.SetBinding(Entry.TextProperty, "Email");
            layout.Children.Add(email);

            var password = new Entry { Placeholder = "Password", IsPassword = true };
            password.SetBinding(Entry.TextProperty, "Password");
            layout.Children.Add(password);

            var name = new Entry { Placeholder = "Name", };
            name.SetBinding(Entry.TextProperty, "Name");
            layout.Children.Add(name);

            var button = new Button { Text = "Save", TextColor = Color.White };
            button.SetBinding(Button.CommandProperty, "LoginCommand");

            layout.Children.Add(button);

            Content = new ScrollView { Content = layout }; 

        #endregion
        }
    }
}
