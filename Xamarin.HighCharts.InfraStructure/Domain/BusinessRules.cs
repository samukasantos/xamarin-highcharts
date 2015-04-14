

namespace Xamarin.HighCharts.InfraStructure.Domain
{
    public class BusinessRules
    {

        #region Properties

        public string DescriptionRule { get; private set; }

        #endregion

        #region Constructor

        public BusinessRules(string descriptionRule)
        {
            DescriptionRule = descriptionRule;
        }

        #endregion
    }
}
