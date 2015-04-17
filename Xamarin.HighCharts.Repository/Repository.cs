
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.HighCharts.InfraStructure.DependencyService;
using Xamarin.HighCharts.InfraStructure.Domain.Interfaces;
using Xamarin.HighCharts.InfraStructure.UnitWork;
using Xamarin.HighCharts.Repository.Context.Interface;
using Xamarin.HighCharts.Repository.Database.Interfaces;

namespace Xamarin.HighCharts.Repository
{
    public abstract class Repository<AggregateType, DatabaseType> : IUnitWorkRepository
        where DatabaseType : IDatabaseModel
        where AggregateType : IAggregateRoot
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
            
            _unitWork  = DependencyResolver.Container.GetService<IUnitWork>();
            _dbContext = DependencyResolver.Container.GetService<IDBContext>();

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

        public void Save(AggregateType aggregate) 
        {
            _unitWork.RegisterSave(aggregate, this);
        }
        public void Update(AggregateType aggregate) 
        {
            _unitWork.RegisterUpdate(aggregate, this);
        }
        public void Delete(AggregateType aggregate) 
        {
            _unitWork.RegisterDelete(aggregate, this);
        }

        public abstract IDatabaseModel ConvertToDatabaseType(IAggregateRoot aggregateRoot);
        public abstract AggregateType FindByToken(string id);

        #endregion

    }
}
