
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Xamarin.HighCharts.InfraStructure.Domain.Exceptions;

namespace Xamarin.HighCharts.InfraStructure.Domain
{
    public abstract class ValueObject : INotifyPropertyChanged
    {
        #region Fields

        private int _id;
        private List<BusinessRules> _brokenRules;

        #endregion

        #region Properties

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

        public ValueObject()
        {
            _brokenRules = new List<BusinessRules>();
        }

        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Methods

        protected abstract void Validate();

        public void ThrowExceptionIfInvalid()
        {
            _brokenRules.Clear();
            Validate();

            if (_brokenRules.Any())
            {
                var summary = new StringBuilder();

                foreach (var rule in _brokenRules)
                    summary.AppendLine(rule.DescriptionRule);

                throw new InvalidValueObjectException(summary.ToString());
            }
        }

        protected void AddRule(BusinessRules rule)
        {
            _brokenRules.Add(rule);
        }

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

        #endregion
    }
}
