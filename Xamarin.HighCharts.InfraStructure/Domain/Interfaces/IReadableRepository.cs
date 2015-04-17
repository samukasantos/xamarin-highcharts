
namespace Xamarin.HighCharts.InfraStructure.Domain.Interfaces
{
    public interface IReadableRepository<AggregateType>
        where AggregateType : IAggregateRoot
    {
        AggregateType FindById(int id);

    }
}
