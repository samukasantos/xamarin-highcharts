using System;
using Xamarin.Highcharts.Domain.ValueObjects;

namespace Xamarin.HighCharts.Domain.Entities
{
	public interface IExpense :IDomain
    {

        string Description{ get; set; }
        ICategory Category{ get; set; }
        string Value{ get; set; }
        DateTime Date{ get; set; }
        string UUID { get; set; }
       
    }
}
