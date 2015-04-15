using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xamarin.HighCharts.Page
{
    public class MenuPage : ContentPage
    {
        public ListView Menu { get; set; }

        public MenuPage()
        {

            Title = "Menu";
           // Icon = "settings.png";
            BackgroundColor = Color.FromHex("1a1c20");

            Menu = new MenuListView();



            var layout = new StackLayout
            {
                Spacing = 0,
                VerticalOptions = LayoutOptions.FillAndExpand

            };

            layout.Children.Add(Menu);


            Content = layout;
        }


    }
}
