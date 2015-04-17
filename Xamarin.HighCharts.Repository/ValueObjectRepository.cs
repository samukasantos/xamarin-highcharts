

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
            throw new System.NotImplementedException();
        }

        public override ValueObjectType FindById(int id)
        {
            throw new System.NotImplementedException();
        }

        #endregion
       
    }
}
