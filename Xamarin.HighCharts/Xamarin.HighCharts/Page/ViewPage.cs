using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.HighCharts.ViewModel;

namespace Xamarin.HighCharts.Page
{
    public class ViewPage<T> : ContentPage where T:IViewModel, new()
    {
        readonly T _viewModel; 

        public T ViewModel
        {
            get {
                return _viewModel;
            }
        }

        public ViewPage ()
        {
            _viewModel = new T ();
            BindingContext = _viewModel;
        }
    }
   
}
