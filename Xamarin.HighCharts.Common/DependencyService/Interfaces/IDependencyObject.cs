
using System;
using Xamarin.HighCharts.Common.DependencyService.Enumerators;

namespace Xamarin.HighCharts.Common.DependencyService.Interfaces
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
