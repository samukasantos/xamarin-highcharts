using System;
using System.Linq.Expressions;
using System.Reflection;
using Xamarin.HighCharts.InfraStructure.Domain;
using Xamarin.HighCharts.InfraStructure.Domain.Interfaces;

namespace Xamarin.HighCharts.Domain.Entities
{
    public class Expense : EntityBase<Expense>, IExpense, IAggregateRoot
    {

        #region Fields

        private string _description;
        private int _category;
        private string _date;
        private string _value;

        #endregion

        #region Properties
        public string Description
        {
            get { return _description; }
			set { _description = value;   RaisedPropertyChanged(()=> Description); }
        }

        public int Category
        {
            get { return _category; }
			set { _category = value; RaisedPropertyChanged(()=> Category); }
        }

        public string Value
        {
            get { return _value; }
			set { _value = value;RaisedPropertyChanged(()=> Value);  }
        }

        public string Date
        {
            get { return _date; }
			set { _date = value;RaisedPropertyChanged(()=> Date);  }
        }

        #endregion

		#region Overridable
		protected override void Validate()
		{
			if (string.IsNullOrEmpty (Description) || string.IsNullOrEmpty (Value) || string.IsNullOrEmpty (Date))
				AddRule (ExpenseBusinessRules.Required);
		
			//Category.ThrowExceptionIfInvalid();
		}

		protected override void ValidateWithCriteria (params Expression<Func<Expense, object>>[] properties)
		{
			var currentDomain = this.GetType().GetTypeInfo();

			foreach (var prop in properties)
			{
				var member = prop.Body as MemberExpression;
				if (member != null) 
				{
					var pInfo    = member.Member as PropertyInfo;
					var property = currentDomain.GetDeclaredProperty(pInfo.Name);     
					var value    = (string)property.GetValue(this, null);

					if (string.IsNullOrEmpty(value))
					{
						AddRule(new BusinessRules(string.Format(UserBusinessRules.Required.DescriptionRule, pInfo.Name)));
					}

				}
			}
		}


		#endregion
    }
}
