
using System;
using Xamarin.HighCharts.Common.DependencyService.Enumerators;
using Xamarin.HighCharts.Common.DependencyService.Interfaces;

namespace Xamarin.HighCharts.Common.DependencyService
{
    public class DependencyObject : IDependencyObject
    {
        #region Properties

        public Type InterfaceType { get; private set; }
        public Type ClassType { get; private set; }
        public LifetimeType Lifetime  { get; private set; }
        public string Name { get; private set; }
		public object[] Parameters { get; private set; }
        public string ParserName { get; set; }
        public object Instance { get; set; }

        #endregion

        #region Constructor

        public DependencyObject(Type interfaceType, object instance)
        {
            InterfaceType = interfaceType;
            Instance = instance;
        }

        public DependencyObject(Type interfaceType, Type classType, LifetimeType lifetimeType = LifetimeType.ContainerController)
        {
            InterfaceType = interfaceType;
            ClassType = classType;
            Lifetime = lifetimeType;
        }

		public DependencyObject(Type interfaceType, Type classType, LifetimeType lifetimeType, string name)
		{
			InterfaceType = interfaceType;
			ClassType = classType;
			Lifetime = lifetimeType;
			Name = name;
		}

		public DependencyObject(Type interfaceType, Type classType, LifetimeType lifetimeType, string name, string parserName = null, params object[] parameters)
        {
            InterfaceType = interfaceType;
            ClassType = classType;
            Lifetime = lifetimeType;
            Name = name;
            ParserName = parserName;
			Parameters = parameters ?? new object[]{};
        }
        
        #endregion
    }
}
