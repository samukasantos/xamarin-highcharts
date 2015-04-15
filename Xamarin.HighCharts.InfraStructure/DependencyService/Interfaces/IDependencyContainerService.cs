
using System.Collections.Generic;

namespace Xamarin.HighCharts.InfraStructure.DependencyService.Interfaces
{
    public interface IDependencyContainerService
    {
        void ContainerStart();
        IList<IDependencyObject> SetDependencies();
    }
}
