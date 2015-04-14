
using Xamarin.HighCharts.InfraStructure.Domain.Interfaces;

namespace Xamarin.HighCharts.InfraStructure.UnitWork
{
    public interface IUnitWork
    {
        void RegisterUpdate(IAggregateRoot aggregateRoot, IUnitWorkRepository repository);
        void RegisterSave(IAggregateRoot aggregateRoot, IUnitWorkRepository repository);
        void RegisterDelete(IAggregateRoot aggregateRoot, IUnitWorkRepository repository);
        void Commit();
    }
}
