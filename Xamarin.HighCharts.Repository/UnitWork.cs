
using Xamarin.HighCharts.InfraStructure.UnitWork;
using Xamarin.HighCharts.InfraStructure.Domain.Interfaces;
using System.Collections.Generic;

namespace Xamarin.HighCharts.Repository
{
    public class UnitWork : IUnitWork
    {
        #region Fields

        //private Dictionary<IAggregateRoot, IUnitWorkRepository> _saveAggregates;
        //private Dictionary<IAggregateRoot, IUnitWorkRepository> _updateAggregates;
        //private Dictionary<IAggregateRoot, IUnitWorkRepository> _deleteggregates;

        private AggregateUnitDictionary _saveAggregates;
        private AggregateUnitDictionary _updateAggregates;
        private AggregateUnitDictionary _deleteggregates;

        

        #endregion

        #region Constructor

        public UnitWork()
        {
            //_saveAggregates   = new Dictionary<IAggregateRoot, IUnitWorkRepository>();
            //_updateAggregates = new Dictionary<IAggregateRoot, IUnitWorkRepository>();
            //_deleteggregates  = new Dictionary<IAggregateRoot, IUnitWorkRepository>();

            _saveAggregates   = new AggregateUnitDictionary();
            _updateAggregates = new AggregateUnitDictionary();
            _deleteggregates  = new AggregateUnitDictionary();
        }

        #endregion

        #region IUnitWork members
        public void RegisterUpdate(IAggregateRoot aggregateRoot, IUnitWorkRepository repository)
        {
            if (!_updateAggregates.ContainsKey(aggregateRoot))
            {
                _updateAggregates.Add(aggregateRoot, repository);
            }
        }

        public void RegisterSave(IAggregateRoot aggregateRoot, IUnitWorkRepository repository)
        {
            if (!_saveAggregates.ContainsKey(aggregateRoot))
            {
                _saveAggregates.Add(aggregateRoot, repository);
            }
        }

        public void RegisterDelete(IAggregateRoot aggregateRoot, IUnitWorkRepository repository)
        {
            if (!_deleteggregates.ContainsKey(aggregateRoot)) 
            {
                _deleteggregates.Add(aggregateRoot, repository);
            }
        }

        public void Commit()
        {
            foreach (var aggregateKey in _saveAggregates.Keys)
            {
                _saveAggregates[aggregateKey].PersistSave(aggregateKey);   
            }

            foreach (var aggregateKey in _updateAggregates.Keys)
            {
                _updateAggregates[aggregateKey].PersistUpdate(aggregateKey);
            }

            foreach (var aggregateKey in _deleteggregates.Keys)
            {
                _deleteggregates[aggregateKey].PersistDelete(aggregateKey);
            }

        }

        #endregion


       
    }
}
