using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.HighCharts.Domain.Entities;
using Xamarin.HighCharts.InfraStructure.DependencyService;

namespace Xamarin.HighCharts.Page
{
    public class ListViewExpensePage : ContentPage
    {
        protected override void OnParentSet()
        {
            base.OnParentSet();
        }
        public override SizeRequest GetSizeRequest(double widthConstraint, double heightConstraint)
        {
            return base.GetSizeRequest(widthConstraint, heightConstraint);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        public ListViewExpensePage()
        {
            var listView = new ListView
            {
                RowHeight = 40
            };

            var expenseRepository = DependencyResolver.Container.GetService<IExpenseRepository>();
            var expenseList = expenseRepository.FindAll();

            var cell = new DataTemplate(typeof(ListCell));
            cell.SetBinding(TextCell.TextProperty, "Description");
            cell.SetBinding(TextCell.TextProperty, "Value");
            cell.SetBinding(TextCell.TextProperty, "Date");
           


            listView.ItemsSource = expenseList;
            listView.ItemTemplate = cell;

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = { listView }
            };
        }
    }

    public class ListCell : ViewCell
    {
        public ListCell()
        {
            var nameLabel = new Label
            {
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            nameLabel.SetBinding(Label.TextProperty, "Description");

            var value = new Label
            {
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            value.SetBinding(Label.TextProperty, "Value");

            var Date = new Label
            {
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            Date.SetBinding(Label.TextProperty, "Date");


            var viewLayout = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                Children = { nameLabel, value }
            };
            View = viewLayout;
        }
    }


}
