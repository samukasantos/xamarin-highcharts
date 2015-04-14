
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.HighCharts.InfraStructure.Domain.Exceptions;

namespace Xamarin.HighCharts.InfraStructure.Domain
{
    public abstract class ValueObject
    {
        #region Fields

        private List<BusinessRules> _brokenRules;

        #endregion

        #region Constructor

        public ValueObject()
        {
            _brokenRules = new List<BusinessRules>();
        }

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

        #endregion
    }
}
