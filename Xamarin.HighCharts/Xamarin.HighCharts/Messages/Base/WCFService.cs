
using Xamarin.HighCharts.WCFHighChartsService;

namespace Xamarin.HighCharts.Messages.Base
{
    public class WCFService
    {
        #region Fields

        private static IWCFHighChartsService _instance;

        #endregion

        #region Properties

        public static IWCFHighChartsService Instance
        {
            get
            {
                return _instance ?? (_instance = new WCFHighChartsServiceClient());
            }
        }

        #endregion
    }
}
