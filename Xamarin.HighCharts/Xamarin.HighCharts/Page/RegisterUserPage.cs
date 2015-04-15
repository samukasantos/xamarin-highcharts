using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.HighCharts.ViewModel;

namespace Xamarin.HighCharts.Page
{
    public class RegisterUserPage : ContentPage
    {
        public RegisterUserPage()
        {
            BindingContext = new RegisterUserViewModel(Navigation);
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
            email.SetBinding(Entry.TextProperty, RegisterUserViewModel.EmailPropertyName);
            layout.Children.Add(email);

            var password = new Entry { Placeholder = "Password", IsPassword = true };
            password.SetBinding(Entry.TextProperty, RegisterUserViewModel.PasswordPropertyName);
            layout.Children.Add(password);

            var name = new Entry { Placeholder = "Name", };
            name.SetBinding(Entry.TextProperty, RegisterUserViewModel.NamePropertyName);
            layout.Children.Add(name);



            var button = new Button { Text = "Save", TextColor = Color.White };
            button.SetBinding(Button.CommandProperty, LoginViewModel.LoginCommandPropertyName);

            layout.Children.Add(button);

            Content = new ScrollView { Content = layout };
        }
    }
}
