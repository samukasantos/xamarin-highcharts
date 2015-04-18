

using Xamarin.Highcharts.Domain.ValueObjects;

namespace Xamarin.HighCharts.Messages
{
    public interface ICategoryService
    {
        bool AddCategory(Category user);
        void GetAllCategoryInCloud();
    }
}
