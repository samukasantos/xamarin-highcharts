using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.HighCharts.ViewModels.Interfaces;
using Xamarin.HighCharts.Page.Interfaces;
using Xamarin.HighCharts.Page.Context;

namespace Xamarin.HighCharts.Page
{
	public class ExpensePage : ContentPage, IActionMessage
	{
		#region Constructor
		public ExpensePage()
		{
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

			var description = new Entry { Placeholder = "Descrição" };
			description.SetBinding(Entry.TextProperty, "Domain.Description");
			layout.Children.Add(description);

			var value = new Entry { Placeholder = "Valor", IsPassword = true };
			value.SetBinding(Entry.TextProperty, "Domain.Value");
			layout.Children.Add(value);

			var date = new Entry { Placeholder = "Data", };
			date.SetBinding(Entry.TextProperty, "Domain.Data");
			layout.Children.Add(date);

			var button = new Button { Text = "Salvar", TextColor = Color.Black };
			button.SetBinding(Button.CommandProperty, "saveCommand");

			layout.Children.Add(button);

			Content = new ScrollView { Content = layout };

		}

		#endregion
	}
}
