using System;
using Xamarin.HighCharts.Domain;

namespace Xamarin.Highcharts.Domain.ValueObjects
{
    public interface ICategory : IDomain
    {
        string Description { get; set; }
    }
}
