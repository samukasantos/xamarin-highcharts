
using System.Collections.Generic;
using System.Linq;
using Xamarin.HighCharts.InfraStructure.Domain.Interfaces;
using Xamarin.HighCharts.InfraStructure.UnitWork;

namespace Xamarin.HighCharts.Repository
{
    public class AggregateUnitDictionary
    {
        #region Fields

        private List<AggregateUnit> _internalCollection;

        #endregion

        #region Properties

        public List<IAggregateRoot> Keys 
        {
            get { return _internalCollection.Select(c => c.AggregateRoot).ToList(); }
        }

        public IUnitWorkRepository this[IAggregateRoot key] 
        {
            get 
            {
                var item = _internalCollection.FirstOrDefault(c => c.AggregateRoot == key);

                if (item != null)
                    return item.UnitWork;

                return null;
            }
        }

        #endregion

        #region Constructor

        public AggregateUnitDictionary()
        {
            _internalCollection = new List<AggregateUnit>();
        }

        #endregion

        #region Methods

        public void Add( IAggregateRoot aggregateRoot, IUnitWorkRepository repository) 
        {
            _internalCollection.Add(new AggregateUnit { AggregateRoot = aggregateRoot, UnitWork = repository });
        }

        public void Clear() 
        {
            _internalCollection.Clear();
        }

        public bool ContainsKey(IAggregateRoot aggregateRoot) 
        {
            return _internalCollection.Any(c => c.AggregateRoot.UUID == aggregateRoot.UUID);
        }

        #endregion
    }
}
