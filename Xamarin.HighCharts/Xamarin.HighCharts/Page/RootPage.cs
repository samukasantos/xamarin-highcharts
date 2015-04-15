using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.HighCharts.Page.MenuRootPage;
using Xamarin.HighCharts.Page.Navigation;

namespace Xamarin.HighCharts.Page
{
    public class RootPage : Xamarin.Forms.MasterDetailPage
    {

        Color backGroundBolor = Color.FromHex("6fc833");
        public RootPage()
        {
            var menuPage = new MenuPage();

            menuPage.Menu.ItemSelected += (sender, e) => NavigateTo(e.SelectedItem as MenuRootIem);

            Master = menuPage;
            Detail = new CustomNavigationPage(new LoginUserPage())
            {
                BarBackgroundColor = backGroundBolor,
            };



        }

        void NavigateTo(MenuRootIem menu)
        {
            Xamarin.Forms.Page displayPage = (Xamarin.Forms.Page)Activator.CreateInstance(menu.TargetType);

            Detail = new CustomNavigationPage(displayPage)
            {
                BarBackgroundColor = backGroundBolor,
            };
            IsPresented = false;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

        }
    }

}
