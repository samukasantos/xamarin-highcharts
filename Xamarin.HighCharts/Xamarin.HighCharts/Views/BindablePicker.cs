using System;
using System.Collections;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.HighCharts.Utils;

namespace Xamarin.HighCharts.Views
{
    public partial class BindablePicker : Picker
    {
        #region Fields

        private static CodeValueCollection _codeValueCollection;

        public static BindableProperty ItemsSourceProperty =
            BindableProperty.Create<BindablePicker, IEnumerable>(o => o.ItemsSource, default(IEnumerable), BindingMode.TwoWay, null, OnItemsSourceChanged);

        public static BindableProperty SelectedItemProperty =
            BindableProperty.Create<BindablePicker, object>(o => o.SelectedItem, default(object), BindingMode.OneWay, null, OnSelectedItemChanged);

        public static readonly BindableProperty CommandProperty = BindableProperty.Create("Command", typeof(ICommand), typeof(BindablePicker), null, BindingMode.OneWay, null, null, null);

        public static readonly BindableProperty InsertEmptyItemProperty = BindableProperty.Create("InsertEmptyItem", typeof(bool), typeof(BindablePicker), false, BindingMode.OneWay, null, null, null);
		
        #endregion

        #region Constructor

        public BindablePicker() 
        {
            _codeValueCollection = new CodeValueCollection();
            this.SelectedIndexChanged += OnSelectedIndexChanged;
        }
        
        #endregion

        #region Properties

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value);            }
        }

        public object SelectedItem
        {
            get { return (object)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

		public ICommand Command
        {
            get { return (ICommand)base.GetValue(BindablePicker.CommandProperty); }
            set { base.SetValue(BindablePicker.CommandProperty, value); }
        }

        public bool InsertEmptyItem
        {
            get { return (bool)base.GetValue(BindablePicker.InsertEmptyItemProperty); }
            set { base.SetValue(BindablePicker.InsertEmptyItemProperty, value); }
        }

        #endregion

        #region Methods

        private void GetSelectedItem(object item) { }

        private static void OnItemsSourceChanged(BindableObject bindable, IEnumerable oldvalue, IEnumerable newvalue)
        {
            var picker = bindable as BindablePicker;
            picker.Items.Clear();
            if (newvalue != null)
            {
                if (picker.InsertEmptyItem)
                {
                    CodeValue emptyItem = new CodeValue() { Value = "" };
                    picker.Items.Add(" ");
                    _codeValueCollection.Items.Add(emptyItem);
                }

                foreach (var item in newvalue)
                {
                    var codeValue = (CodeValue)item;
                    picker.Items.Add(codeValue.Value);
                    _codeValueCollection.Items.Add(codeValue);
                }
            }
        }

        private void OnSelectedIndexChanged(object sender, EventArgs eventArgs)
        {
            var control = sender as BindablePicker;
            //control.
            
            if (SelectedIndex < 0 || SelectedIndex > Items.Count - 1)
            {
                SelectedItem = null;
            }
            else
            {                
                var index = Convert.ToString(Items[SelectedIndex]).Trim();
                SelectedItem = _codeValueCollection[index];

                if (Command.CanExecute(SelectedItem))
                    Command.Execute(SelectedItem);            
            }
        }

        private static void OnSelectedItemChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            //var picker = bindable as BindablePicker;
            //if (newvalue != null)
            //{
            //    picker.SelectedIndex = picker.Items.IndexOf(newvalue.ToString());
            //}
        }
        
        #endregion
    }
}

