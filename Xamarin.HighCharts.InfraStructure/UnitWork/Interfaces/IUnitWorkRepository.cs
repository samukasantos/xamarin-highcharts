

using xamarin.highcharts.infrastructure.Domain.Interfaces;

namespace xamarin.highcharts.infrastructure.UnitWork.Interfaces
{
    public interface IUnitWorkRepository
    {
        void Save(IAggregateRoot aggregateRoot);
        void Update(IAggregateRoot aggregateRoot);
        void Delete(IAggregateRoot aggregateRoot);
    }
}
