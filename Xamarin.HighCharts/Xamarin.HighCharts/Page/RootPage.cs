using System;
using Xamarin.Forms;
using Xamarin.HighCharts.InfraStructure.DependencyService;
using Xamarin.HighCharts.Messages;
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
            var categoryService = DependencyResolver.Container.GetService<ICategoryService>();

            categoryService.GetAllCategoryInCloud();
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
            if (menu.TargetType != typeof(CarouselExpensePage))
            {
                Xamarin.Forms.Page displayPage = (Xamarin.Forms.Page)Activator.CreateInstance(menu.TargetType);
                Detail = new CustomNavigationPage(displayPage)
                {
                    BarBackgroundColor = backGroundBolor,
                    Title = displayPage.Title
                };
            }
            else
            {
                CarouselExpensePage displayPage = (CarouselExpensePage)Activator.CreateInstance(menu.TargetType);
                Detail = new CustomNavigationPage(displayPage)
                {
                    BarBackgroundColor = backGroundBolor,
                    Title = displayPage.Title
                };
            }


            IsPresented = false;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        #endregion
    }

}
