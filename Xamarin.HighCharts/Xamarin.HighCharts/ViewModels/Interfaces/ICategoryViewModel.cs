
using Xamarin.Forms;
using Xamarin.HighCharts.ViewModels.Base.Interfaces;

namespace Xamarin.HighCharts.ViewModels.Interfaces
{
    public interface ICategoryViewModel : ICommonCommand, IViewModel
    {
        Command SaveCommand { get; }
    }
}
