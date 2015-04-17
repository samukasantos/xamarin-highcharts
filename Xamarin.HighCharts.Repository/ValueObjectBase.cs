
using Xamarin.HighCharts.InfraStructure.DependencyService;
using Xamarin.HighCharts.InfraStructure.Domain.Interfaces;
using Xamarin.HighCharts.Repository.Context.Interface;
using Xamarin.HighCharts.Repository.Database.Interfaces;

namespace Xamarin.HighCharts.Repository
{
    public abstract class ValueObjectBase<ValueObjectType, DatabaseType> : IValueObjectRepository<ValueObjectType>
        where ValueObjectType : IValueObject
        where DatabaseType : IDatabaseModel
    {
        #region Fields

        private readonly IDBContext _dbContext;

        #endregion

        #region Properties

        public IDBContext DBContext
        {
            get
            {
                return _dbContext;
            }
        }

        #endregion

        #region Constructor

        public ValueObjectBase()
        {
            _dbContext = DependencyResolver.Container.GetService<IDBContext>();

            _dbContext.Initialize<DatabaseType>();
        }

        #endregion

        #region Methods

        public void Save(ValueObjectType databaseModel) 
        {
            _dbContext.Save(ConvertToDatabaseType(databaseModel));
        }

        public void Update(ValueObjectType databaseModel)
        {
            _dbContext.Update(ConvertToDatabaseType(databaseModel));
        }

        public void Delete(ValueObjectType databaseModel)
        {
            _dbContext.Delete(ConvertToDatabaseType(databaseModel));
        }
        public abstract IDatabaseModel ConvertToDatabaseType(IValueObject valueObject);
        public abstract ValueObjectType FindById(int id);

        #endregion
    }
}
