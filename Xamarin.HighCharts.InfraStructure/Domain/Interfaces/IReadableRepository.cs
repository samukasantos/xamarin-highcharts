
namespace Xamarin.HighCharts.InfraStructure.Domain.Interfaces
{
    public interface IReadableRepository<AggregateType, IdType>
        where AggregateType : IAggregateRoot
    {
        AggregateType FindById(IdType id);

    }
}
