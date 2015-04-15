using System;
using Xamarin.Forms;
using Xamarin.HighCharts.Page.MenuRootPage;
using Xamarin.HighCharts.Page.Navigation;

namespace Xamarin.HighCharts.Page
{
    public class RootPage : Xamarin.Forms.MasterDetailPage
    {
        #region Fields

        private Color backGroundBolor = Color.FromHex("6fc833"); 
        #endregion

        #region Constructor
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
        
        #endregion

        #region Methods

        private void NavigateTo(MenuRootIem menu)
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

        #endregion
    }

}
