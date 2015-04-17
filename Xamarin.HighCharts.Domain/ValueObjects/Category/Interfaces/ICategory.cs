using System;
using Xamarin.HighCharts.Domain;

namespace Xamarin.Highcharts.Domain.ValueObjects
{
    public interface ICategory : IDomain
    {
        int Id { get; set; }
        string Description { get; set; }
    }
}
