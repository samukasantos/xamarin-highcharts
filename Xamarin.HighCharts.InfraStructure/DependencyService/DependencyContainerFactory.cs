
using System.Linq;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using Xamarin.HighCharts.InfraStructure.DependencyService.Interfaces;

namespace Xamarin.HighCharts.InfraStructure.DependencyService
{
    public static class DependencyContainerFactory
    {
        #region Fields

        private static IUnityContainer _container;
        
        #endregion

        #region Properties

        public static IUnityContainer Container
        {
            get
            {
                return _container ?? (_container = new UnityContainer());
            }
        } 

        #endregion

        #region Methods

        public static IUnityContainer GetContainer(IList<IDependencyObject> dependencies)
        {
            var container = Container;

            foreach (var dependency in dependencies)
            {
                var lifetime = dependency.Lifetime == Enumerators.LifetimeType.Transient ? null : new ContainerControlledLifetimeManager();

                if (lifetime != null)
                {
                    if (dependency.Parameters == null)
                    {
                        if (!string.IsNullOrEmpty(dependency.ParserName))
                        {
                            container.RegisterType(dependency.InterfaceType, dependency.ClassType, dependency.ParserName, lifetime, null);
                        }
                        else
                        {
                            container.RegisterType(dependency.InterfaceType, dependency.ClassType, lifetime);
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(dependency.ParserName))
                        {
                            container.RegisterType(dependency.InterfaceType, dependency.ClassType, dependency.ParserName, lifetime, new InjectionMember[] { new InjectionConstructor(dependency.Parameters) });
                        }
                        else
                        {
                            container.RegisterType(dependency.InterfaceType, dependency.ClassType, lifetime, new InjectionConstructor(dependency.Parameters));
                        }
                    }
                }
                else
                {
                    if (dependency.Instance != null)
                    {
                        container.RegisterInstance(dependency.InterfaceType, dependency.Instance);
                    }
                    else if (dependency.Parameters == null)
                    {
                        if (!string.IsNullOrEmpty(dependency.ParserName))
                        {
                            container.RegisterType(dependency.InterfaceType, dependency.ClassType, dependency.ParserName, null);
                        }
                        else
                        {
                            container.RegisterType(dependency.InterfaceType, dependency.ClassType);
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(dependency.ParserName))
                        {
                            container.RegisterType(dependency.InterfaceType, dependency.ClassType, dependency.ParserName, new InjectionConstructor(dependency.Parameters));
                        }
                        else
                        {
                            container.RegisterType(dependency.InterfaceType, dependency.ClassType, new InjectionConstructor(dependency.Parameters));
                        }
                    }
                }
            }

            return container;
        } 
        #endregion
    }
}
