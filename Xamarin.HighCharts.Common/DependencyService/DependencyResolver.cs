
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using Xamarin.HighCharts.Common.DependencyService.Interfaces;

namespace Xamarin.HighCharts.Common.DependencyService
{
    public class DependencyResolver : IDependencyResolver
    {
        #region Fields

        private static DependencyResolver _container;
        private static IUnityContainer _unityContainer;

        #endregion

        #region Properties

        public static DependencyResolver Container 
        {
            get { return _container ?? ( _container = new DependencyResolver()); }
        }

        #endregion

        #region Methods

        public void UnityInjection(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
        }

        #endregion

        #region IDependencyResolver members

        public object GetService(Type type)
        {
            if (!_unityContainer.IsRegistered(type))
                return null;

            return _unityContainer.Resolve(type);
        }

        public object GetService(Type type, string parameterName, object value)
        {
            if (!_unityContainer.IsRegistered(type))
                return null;

            return _unityContainer.Resolve(type, new ParameterOverride(parameterName, value));
        }

        public object GetService(Type type, string parserName, string parameterName, object value)
        {   
            return _unityContainer.Resolve(type, parserName, new ParameterOverride(parameterName, value));
        }

        public T GetService<T>()
        {
            if (!_unityContainer.IsRegistered(typeof(T)))
                return default(T);

            return _unityContainer.Resolve<T>();
        }
		public T GetService<T>(string parameterName, object value)
		{
			if (!_unityContainer.IsRegistered(typeof(T)))
				return default(T);

			return _unityContainer.Resolve<T>(new ParameterOverride(parameterName, value));
		}

        public IEnumerable<T> GetServices<T>()
        {
            if (!_unityContainer.IsRegistered(typeof(T)))
                return default(IEnumerable<T>);

            return _unityContainer.ResolveAll<T>();
        }

        public object GetServiceByType(Type type)
        {
            if (!_unityContainer.IsRegistered(type))
                return null;

            return _unityContainer.Resolve(type, new ResolverOverride[]{});
        }

        public object GetServiceByType(Type type, string parameterName, object value)
        {
            if (!_unityContainer.IsRegistered(type))
                return null;

            return _unityContainer.Resolve(type, new ParameterOverride(parameterName, value));
        }


        #endregion

    }
}
