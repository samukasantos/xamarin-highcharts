

using Xamarin.HighCharts.Domain.ValueObjects;
using Xamarin.HighCharts.InfraStructure.Domain.Interfaces;
using Xamarin.HighCharts.Repository.Database.Interfaces;

namespace Xamarin.HighCharts.ViewModels.Base.Interfaces
{
    public interface ICategoryRepositoryService<ValueObjectType>
     where ValueObjectType : IValueObject

    {
        IValueObjectRepository<ValueObjectType> Repository { get; }
    }
}
