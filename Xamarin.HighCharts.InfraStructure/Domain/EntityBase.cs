
using System.Collections.Generic;

namespace Xamarin.HighCharts.InfraStructure.Domain
{
    public abstract class EntityBase<IdType>
    {
        #region Fields

        private List<BusinessRules> _brokenRules;

        #endregion

        #region Properties

        public IdType Id { get; set; }

        #endregion

        #region Constructor

        public EntityBase()
        {
            _brokenRules = new List<BusinessRules>();
        }

        #endregion

        #region Overridable

        public override bool Equals(object entity)
        {
            return entity != null && entity is EntityBase<IdType>
                && this == (EntityBase<IdType>)entity;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        #endregion

        #region Operators

        public static bool operator ==(EntityBase<IdType> entityLeft, EntityBase<IdType> entityRight)
        {
            if ((object)entityLeft == null && (object)entityRight == null)
            {
                return true;
            }

            if ((object)entityLeft == null || (object)entityRight == null)
            {
                return false;
            }

            if (entityLeft.Id.ToString() == entityRight.Id.ToString())
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(EntityBase<IdType> entityLeft, EntityBase<IdType> entityRight)
        {
            return (!(entityLeft == entityRight));
        }

        #endregion

        #region Methods

        protected abstract void Validate();

        protected void AddRule(BusinessRules rule)
        {
            _brokenRules.Add(rule);
        }

        public IEnumerable<BusinessRules> GetBrokenRules()
        {
            _brokenRules.Clear();
            Validate();
            return _brokenRules;
        }

        #endregion

    }
}
