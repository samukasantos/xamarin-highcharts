
using xamarin.highcharts.domain.ValueObjects.Interfaces;
using xamarin.highcharts.infrastructure.Domain;

namespace xamarin.highcharts.domain.ValueObjects
{
    public class Category : ValueObject, ICategory
    {
        #region Properties
        public string Name { get; set; }
        public string Description { get; set; } 
        #endregion

        #region Overridables

        protected override void Validate()
        {
            if (string.IsNullOrEmpty(Name))
                AddRule(CategoryBusinessRules.NameRequired);

            if (string.IsNullOrEmpty(Description))
                AddRule(CategoryBusinessRules.DescriptionRequired);

        }

        #endregion
    }
}
