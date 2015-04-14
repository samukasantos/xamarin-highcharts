
using Xamarin.HighCharts.InfraStructure.Domain.Interfaces;

namespace Xamarin.HighCharts.InfraStructure.UnitWork
{
    public interface IUnitWorkRepository
    {
        void PersistSave(IAggregateRoot aggregate);
        void PersistUpdate(IAggregateRoot aggregate);
        void PersistDelete(IAggregateRoot aggregate);
    }
}
