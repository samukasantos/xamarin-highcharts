using Newtonsoft.Json;
using System;
using System.Threading;
using Xamarin.HighCharts.Domain;
using Xamarin.HighCharts.InfraStructure.DependencyService;
using Xamarin.HighCharts.WCFHighChartsService;

namespace Xamarin.HighCharts.Base.Messages
{
    public abstract class ServiceBase
    {
        #region Fields

        private readonly AutoResetEvent _autoResetEvent = new AutoResetEvent(false);

        #endregion

        #region Properties

        public AutoResetEvent AutoResetEvent { get { return _autoResetEvent; } }

        public Exception CurrentException { get; set; }

        public WCFHighChartsServiceClient Client
        {
            get
            {
                return DependencyResolver.Container.GetService<IWCFHighChartsService>() as WCFHighChartsServiceClient;
            }

        }

        #endregion

        #region Constructor

        public ServiceBase() { }

        #endregion

    }
}
