
using Xamarin.HighCharts.InfraStructure.Domain.Interfaces;
using Xamarin.HighCharts.InfraStructure.UnitWork;
namespace Xamarin.HighCharts.Repository
{
    public class AggregateUnit
    {
        public IAggregateRoot AggregateRoot { get; set; }
        public IUnitWorkRepository UnitWork { get; set; }
    }
}
