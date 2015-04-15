
using System;
using System.Collections.Generic;

namespace Xamarin.HighCharts.InfraStructure.DependencyService.Interfaces
{
    public interface IDependencyResolver
    {
        object GetService(Type type);
        object GetService(Type type, string parameterName, object value);
        object GetService(Type type, string parserName, string parameterName, object value);
        T GetService<T>();
        T GetService<T>(string parameterName, object value);
        IEnumerable<T> GetServices<T>();
    }
}
