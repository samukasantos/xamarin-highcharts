

using Xamarin.HighCharts.InfraStructure.Domain.Interfaces;
using Xamarin.HighCharts.Repository.Database.Interfaces;

namespace Xamarin.HighCharts.Repository
{
    public class ValueObjectRepository<ValueObjectType, DatabaseType> : ValueObjectBase<ValueObjectType, DatabaseType>
        where ValueObjectType : IValueObject
        where DatabaseType : IDatabaseModel
    {
        #region Methods

        public override IDatabaseModel ConvertToDatabaseType(IValueObject valueObject) 
        {
            return null;
        }

        public override ValueObjectType FindById(int id) 
        {
            return default(ValueObjectType);
        }

        #endregion
       
    }
}
