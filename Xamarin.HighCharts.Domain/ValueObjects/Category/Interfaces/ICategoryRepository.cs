using Xamarin.HighCharts.InfraStructure.Domain.Interfaces;
using Xamarin.Highcharts.Domain.ValueObjects;
using System.Collections.Generic;

namespace Xamarin.HighCharts.Domain.ValueObjects
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> FindAll();
    }
}
