
using System.Collections.Generic;

namespace Xamarin.HighCharts.Common.DependencyService.Interfaces
{
    public interface IDependencyContainerService
    {
        void ContainerStart();
        IList<IDependencyObject> SetDependencies();
    }
}
