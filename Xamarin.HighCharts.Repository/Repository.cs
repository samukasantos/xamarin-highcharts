
using Xamarin.HighCharts.InfraStructure.Domain.Interfaces;
using Xamarin.HighCharts.InfraStructure.UnitWork;
using Xamarin.HighCharts.Repository.Context.Interface;
using Xamarin.HighCharts.Repository.Database.Interfaces;

namespace Xamarin.HighCharts.Repository
{
    public abstract class Repository<AggregateType, IdTtype, DatabaseType> : IUnitWorkRepository
        where DatabaseType : IDatabaseModel
    {

        #region Fields

        private readonly IUnitWork  _unitWork;
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

        public Repository()
        {
            _dbContext.Initialize<DatabaseType>();
        }

        #endregion

        #region IUnitWorkRepository members
        public void PersistSave(IAggregateRoot aggregate)
        {
            _dbContext.Save(ConvertToDatabaseType(aggregate));
        }

        public void PersistUpdate(IAggregateRoot aggregate)
        {
            _dbContext.Update(ConvertToDatabaseType(aggregate));
        }

        public void PersistDelete(IAggregateRoot aggregate)
        {
            _dbContext.Delete(ConvertToDatabaseType(aggregate));
        }
 
        #endregion

        #region Methods

        public void Save(IAggregateRoot aggregate) 
        {
            _unitWork.RegisterSave(aggregate, this);
        }
        public void Update(IAggregateRoot aggregate) 
        {
            _unitWork.RegisterUpdate(aggregate, this);
        }
        public void Delete(IAggregateRoot aggregate) 
        {
            _unitWork.RegisterDelete(aggregate, this);
        }

        public abstract IDatabaseModel ConvertToDatabaseType(IAggregateRoot aggregateRoot);
        public abstract IAggregateRoot FindById(IdTtype id);

        #endregion

    }
}
