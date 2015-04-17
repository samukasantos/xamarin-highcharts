

using Xamarin.Forms;
using Xamarin.HighCharts.Utils;
using Xamarin.HighCharts.Views;

namespace Xamarin.HighCharts.Page
{
    public class BindablePickerPageSample : ContentPage
    {
        #region Properties

        public CodeValue _currentCodeValue;

        #endregion

        public BindablePickerPageSample()
        {
            //1.
            var bindablePicker         = new BindablePicker();
            var label                  = new Label { Text = "Selecione:" };
            //2.
            var collection             = new CodeValueCollection();
            collection.Items.Add(new CodeValue{ Code = "1", Value = "Banana" });
            collection.Items.Add(new CodeValue{ Code = "2", Value = "Pera" });
            collection.Items.Add(new CodeValue{ Code = "3", Value = "Maça" });
            collection.Items.Add(new CodeValue{ Code = "4", Value = "Uva" });
            collection.Items.Add(new CodeValue{ Code = "5", Value = "Melancia" });
            //3.
            bindablePicker.ItemsSource = collection.Items;
            //4.
            bindablePicker.Command = new Command((c) => 
            {
                _currentCodeValue = (CodeValue)c;

                var code  = _currentCodeValue.Code;
                var value = _currentCodeValue.Value;
            });

            Content = new StackLayout
            {
                Children = { label, bindablePicker }
            };
        }
    }
}
