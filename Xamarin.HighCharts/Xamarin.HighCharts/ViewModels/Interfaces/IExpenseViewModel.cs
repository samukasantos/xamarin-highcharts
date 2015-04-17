using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.HighCharts.Utils;
using Xamarin.HighCharts.ViewModels.Base.Interfaces;

namespace Xamarin.HighCharts.ViewModels.Interfaces
{
    public interface IExpenseViewModel : ICommonCommand, IViewModel
    {
        ObservableCollection<CodeValue> Categories { get; set; }
		Command SaveCommand { get; }
        Command CategoriesCommand { get; }
    }
}
