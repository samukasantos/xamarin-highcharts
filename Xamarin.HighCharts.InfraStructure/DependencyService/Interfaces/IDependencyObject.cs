
using System;
using Xamarin.HighCharts.InfraStructure.DependencyService.Enumerators;

namespace Xamarin.HighCharts.InfraStructure.DependencyService.Interfaces
{
    public interface IDependencyObject
    {
        Type InterfaceType { get; }
        Type ClassType     { get; }
        LifetimeType Lifetime { get; }
		object[] Parameters { get; }
        string ParserName { get; }
        object Instance { get; }
    }
}
