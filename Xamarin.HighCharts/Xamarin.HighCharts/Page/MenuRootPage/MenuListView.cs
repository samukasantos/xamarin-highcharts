using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.HighCharts.Page.MenuRootPage;
using Xamarin.HighCharts.Views;

namespace Xamarin.HighCharts.Page
{
    public class MenuListView : ListView
    {
        #region Constructor
        public MenuListView()
        {
            var data = new MenuListData();
            ItemsSource = data;
            VerticalOptions = LayoutOptions.FillAndExpand;
            BackgroundColor = Color.Transparent;

            var cell = new DataTemplate(typeof(CustomImageCell));
            cell.SetBinding(TextCell.TextProperty, "Title");
            cell.SetBinding(ImageCell.ImageSourceProperty, "IconSource");

            ItemTemplate = cell;
            SelectedItem = data[0];
        } 
        #endregion
    }
}
