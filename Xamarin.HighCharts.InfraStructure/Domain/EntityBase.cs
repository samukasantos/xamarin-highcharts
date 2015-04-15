
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;

namespace Xamarin.HighCharts.InfraStructure.Domain
{
    public abstract class EntityBase<IdType, DomainType> : INotifyPropertyChanged
    {
        #region Fields

        private IdType _idType;
        private List<BusinessRules> _brokenRules;

        #endregion

        #region Properties

        public IdType Id 
        {
            get { return _idType; }
            set 
            {
                _idType = value;
                RaisedPropertyChanged(() => Id);
            }
        }

        #endregion

        #region Constructor

        public EntityBase()
        {
            _brokenRules = new List<BusinessRules>();
        }

        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Overridable

        public override bool Equals(object entity)
        {
            return entity != null && entity is EntityBase<IdType, DomainType>
                && this == (EntityBase<IdType, DomainType>)entity;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        #endregion

        #region Operators

        public static bool operator ==(EntityBase<IdType, DomainType> entityLeft, EntityBase<IdType, DomainType> entityRight)
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

        public static bool operator !=(EntityBase<IdType, DomainType> entityLeft, EntityBase<IdType, DomainType> entityRight)
        {
            return (!(entityLeft == entityRight));
        }

        #endregion

        #region Methods

        protected void RaisedPropertyChanged<PropertyType>(Expression<Func<PropertyType>> property)
        {
            var memberExpression = property.Body as MemberExpression;
            var propertyInfo = memberExpression.Member as PropertyInfo;

            if (propertyInfo != null)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyInfo.Name));
            }
        }

        protected abstract void Validate();
        protected abstract void ValidateWithCriteria(params Expression<Func<DomainType, string>>[] properties);

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

        public IEnumerable<BusinessRules> GetBrokenRules(params Expression<Func<DomainType, string>>[] properties)
        {
            _brokenRules.Clear();
            ValidateWithCriteria(properties);
            return _brokenRules;
        }

        #endregion

    }
}
