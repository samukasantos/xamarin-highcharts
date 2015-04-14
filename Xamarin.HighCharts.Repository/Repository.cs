
using Xamarin.HighCharts.InfraStructure.UnitWork;
using Xamarin.HighCharts.InfraStructure.Domain.Interfaces;
using Xamarin.HighCharts.Repository.Context.Interface;

namespace Xamarin.HighCharts.Repository
{
    public abstract class Repository<AggregateType, IdTtype, DatabaseType> : IUnitWorkRepository
    {

        #region Fields

        private readonly IUnitWork _unitWork;
        private readonly IDBContext _dbContext;

        #endregion

        #region Constructor

        public Repository()
        {

        }

        #endregion

        #region IUnitWorkRepository members
        public void PersistSave(IAggregateRoot aggregate)
        {
            _unitWork.RegisterSave(aggregate, this);
        }

        public void PersistUpdate(IAggregateRoot aggregate)
        {
            _unitWork.RegisterUpdate(aggregate, this);
        }

        public void PersistDelete(IAggregateRoot aggregate)
        {
            _unitWork.RegisterDelete(aggregate, this);
        }
 
        #endregion

        #region
        
        #endregion
    }
}
