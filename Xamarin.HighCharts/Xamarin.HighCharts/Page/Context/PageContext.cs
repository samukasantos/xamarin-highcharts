
using Xamarin.Forms;
using Xamarin.HighCharts.InfraStructure.DependencyService;
using Xamarin.HighCharts.Page.Interfaces;
using Xamarin.HighCharts.ViewModels.Base.Interfaces;

namespace Xamarin.HighCharts.Page.Context
{
    public static class PageContext
    {
        public static void BindingContext<InterfaceType>(this BindableObject current) 
            where InterfaceType : IViewModel
        {
            if (current != null) 
            {
                var bindingContext = DependencyResolver.Container.GetService<InterfaceType>("navigation", (current as VisualElement).Navigation);
            
                if (bindingContext != null) 
                {
                    bindingContext.ActionMessage = (IActionMessage)current;
                    current.BindingContext = bindingContext;
                }
            }
        }
    }
}
