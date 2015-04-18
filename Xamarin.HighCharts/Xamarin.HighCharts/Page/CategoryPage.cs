
using Xamarin.Forms;
using Xamarin.HighCharts.Page.Context;
using Xamarin.HighCharts.Page.Interfaces;
using Xamarin.HighCharts.ViewModels.Interfaces;

namespace Xamarin.HighCharts.Page
{
    public class CategoryPage : ContentPage, IActionMessage
    {
        #region Constructor
        public CategoryPage()
        {
            this.Title = "Category Register .:";
            this.BindingContext<ICategoryViewModel>();

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

            var username = new Entry { Placeholder = "Description" };
            username.SetBinding(Entry.TextProperty, "Domain.Description");
            layout.Children.Add(username);


            var button = new Button { Text = "Save", TextColor = Color.White };
            button.SetBinding(Button.CommandProperty, "SaveCommand");

            layout.Children.Add(button);
            Content = new ScrollView { Content = layout };
        }

        #endregion
    }
}
