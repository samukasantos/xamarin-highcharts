using Xamarin.HighCharts.InfraStructure.Domain.Interfaces;

namespace Xamarin.HighCharts.Repository.Database.Interfaces
{
    public interface IValueObjectRepository<ValueObjectType>
     where ValueObjectType : IValueObject
    {
        void Delete(ValueObjectType databaseModel);
        ValueObjectType FindById(int id);
        void Save(ValueObjectType databaseModel);
        void Update(ValueObjectType databaseModel);
    }
}
