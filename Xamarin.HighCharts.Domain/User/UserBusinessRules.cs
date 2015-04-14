

using Xamarin.HighCharts.InfraStructure.Domain;

namespace Xamarin.HighCharts.Domain
{
    public static class UserBusinessRules
    {
        #region Fields

        //TODO .: Use internationalization for messages.
        public static readonly BusinessRules UserNameRequired = new BusinessRules("Name is required.");

        #endregion
    }
}
