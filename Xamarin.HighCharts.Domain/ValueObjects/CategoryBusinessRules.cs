

using xamarin.highcharts.infrastructure.Domain;

namespace xamarin.highcharts.domain.ValueObjects
{
    public static class CategoryBusinessRules
    {
        #region Fields

        public static readonly BusinessRules NameRequired = new BusinessRules("Name is required.");
        public static readonly BusinessRules DescriptionRequired = new BusinessRules("Description is required.");


        #endregion
    }
}
