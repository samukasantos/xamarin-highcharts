

using Xamarin.Forms;
using Xamarin.HighCharts.Page.Interfaces;

namespace Xamarin.HighCharts.ViewModels.Base.Interfaces
{
    public interface IViewModel
    {
        INavigation Navigation { get; }
        IActionMessage ActionMessage { get; set; }
    }
}
