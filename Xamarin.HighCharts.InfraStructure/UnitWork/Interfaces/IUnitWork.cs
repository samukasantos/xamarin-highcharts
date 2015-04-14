
using xamarin.highcharts.infrastructure.Domain.Interfaces;

namespace xamarin.highcharts.infrastructure.UnitWork.Interfaces
{
    public interface IUnitWork
    {
        void RegisterInsert(IAggregateRoot aggregateRoot, IUnitWorkRepository repository);
        void RegisterUpdate(IAggregateRoot aggregateRoot, IUnitWorkRepository repository);
        void RegisterDelete(IAggregateRoot aggregateRoot, IUnitWorkRepository repository);
        void Submit();
    }
}
