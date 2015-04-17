
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;

namespace Xamarin.HighCharts.InfraStructure.Domain
{
    public abstract class EntityBase<DomainType> : INotifyPropertyChanged
    {
        #region Fields

        private int _id;
        private List<BusinessRules> _brokenRules;

        #endregion

        #region Properties

        public string UUID { get; private set; }
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                RaisedPropertyChanged(() => Id);
            }
        }


        #endregion

        #region Constructor

        public EntityBase()
        {
            _brokenRules = new List<BusinessRules>();
            UUID = Guid.NewGuid().ToString(); 
        }

        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Overridable

        public override bool Equals(object entity)
        {
            return entity != null && entity is EntityBase<DomainType>
                && this == (EntityBase<DomainType>)entity;
        }

        public override int GetHashCode()
        {
            return this.GetHashCode();
        }

        #endregion

        #region Operators

        public static bool operator ==(EntityBase<DomainType> entityLeft, EntityBase<DomainType> entityRight)
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

        public static bool operator !=(EntityBase<DomainType> entityLeft, EntityBase<DomainType> entityRight)
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
        protected abstract void ValidateWithCriteria(params Expression<Func<DomainType, object>>[] properties);

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

        public IEnumerable<BusinessRules> GetBrokenRules(params Expression<Func<DomainType, object>>[] properties)
        {
            _brokenRules.Clear();
            ValidateWithCriteria(properties);
            return _brokenRules;
        }

        #endregion

    }
}
