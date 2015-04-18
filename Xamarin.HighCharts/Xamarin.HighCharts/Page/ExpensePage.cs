using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.HighCharts.ViewModels.Interfaces;
using Xamarin.HighCharts.Page.Interfaces;
using Xamarin.HighCharts.Page.Context;
using Xamarin.HighCharts.Views;

namespace Xamarin.HighCharts.Page
{
	public class ExpensePage : ContentPage, IActionMessage
	{
		#region Constructor
		public ExpensePage()
		{
            this.Title = "Expense Register .:";
			this.BindingContext<IExpenseViewModel>();

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

            var labelCategory = new Label { Text = "Category:", FontSize = 12 };
            layout.Children.Add(labelCategory);

            var bindablePicker = new BindablePicker();
            bindablePicker.SetBinding(BindablePicker.ItemsSourceProperty, "Categories");
            bindablePicker.SetBinding(BindablePicker.CommandProperty, "CategoriesCommand");
            bindablePicker.SetBinding(BindablePicker.IsEnabledProperty, "CategoryVisibility");
            bindablePicker.SetBinding(BindablePicker.SelectedIndexProperty, "CategorySelectedIndex");
            layout.Children.Add(bindablePicker);

			var description = new Entry { Placeholder = "Description" };
			description.SetBinding(Entry.TextProperty, "Domain.Description");
			layout.Children.Add(description);

			var value = new Entry { Placeholder = "Value" };
			value.SetBinding(Entry.TextProperty, "Domain.Value");
			layout.Children.Add(value);

            var labelDate = new Label { Text = "Cost Date:", FontSize = 12 };
            layout.Children.Add(labelDate);

            //var date = new Entry { Placeholder = "Date", };
            var date = new DatePicker { Format = "D" };
            date.SetBinding(DatePicker.DateProperty, "Domain.Date");
			layout.Children.Add(date);

			var button = new Button { Text = "Salvar", TextColor = Color.Black };
			button.SetBinding(Button.CommandProperty, "SaveCommand");

			layout.Children.Add(button);

			Content = new ScrollView { Content = layout };

		}

		#endregion
	}
}
