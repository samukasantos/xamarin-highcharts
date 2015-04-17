
namespace Xamarin.HighCharts.InfraStructure.Domain.Interfaces
{
    public interface IRepository<AggregateType> : IReadableRepository<AggregateType>
        where AggregateType : IAggregateRoot
    {
        void Update(AggregateType aggregate);
        void Save(AggregateType aggregate);
        void Delete(AggregateType aggregate);
    }
}
