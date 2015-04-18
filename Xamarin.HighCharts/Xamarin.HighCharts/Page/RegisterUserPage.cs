using Xamarin.Forms;
using Xamarin.HighCharts.ViewModel;
using Xamarin.HighCharts.InfraStructure.DependencyService;
using Xamarin.HighCharts.ViewModels.Interfaces;
using Xamarin.HighCharts.Page.Context;
using Xamarin.HighCharts.Page.Interfaces;

namespace Xamarin.HighCharts.Page
{
    public class RegisterUserPage : ContentPage, IActionMessage
    {
        #region Constructor
        public RegisterUserPage()
        {
            this.Title = "User Register .:";
            this.Icon = "ic_usuario.png";
            this.BindingContext<IRegisterUserViewModel>();

            var layout = new StackLayout { Padding = 10 };
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
            email.SetBinding(Entry.TextProperty, "Domain.Email");
            layout.Children.Add(email);

            var password = new Entry { Placeholder = "Password", IsPassword = true };
            password.SetBinding(Entry.TextProperty, "Domain.Password");
            layout.Children.Add(password);

            var name = new Entry { Placeholder = "Name", };
            name.SetBinding(Entry.TextProperty, "Domain.Name");
            layout.Children.Add(name);

            var button = new Button { Text = "Save", TextColor = Color.Black };
            button.SetBinding(Button.CommandProperty, "SaveCommand");

            layout.Children.Add(button);

            Content = new ScrollView { Content = layout };

        }
        #endregion

    }
}
