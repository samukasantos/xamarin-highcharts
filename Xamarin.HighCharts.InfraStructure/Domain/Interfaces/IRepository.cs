
namespace Xamarin.HighCharts.InfraStructure.Domain.Interfaces
{
    public interface IRepository<AggregateType, IdType> : IReadableRepository<AggregateType, IdType>
        where AggregateType : IAggregateRoot
    {
        void Update(AggregateType aggregate);
        void Save(AggregateType aggregate);
        void Delete(AggregateType aggregate);
    }
}
