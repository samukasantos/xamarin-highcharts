
using Xamarin.Highcharts.Domain.ValueObjects;
using Xamarin.HighCharts.InfraStructure.Domain;
using Xamarin.HighCharts.InfraStructure.Domain.Interfaces;

namespace Xamarin.Highcharts.Domain.ValueObjects
{
    public class Category : ValueObject, ICategory, IValueObject
    {

        #region Properties

        public string Description { get; set; } 
        #endregion

        #region Overridables

        protected override void Validate()
        {
            if (string.IsNullOrEmpty(Description))
                AddRule(CategoryBusinessRules.DescriptionRequired);
        }

        #endregion
    }
}
