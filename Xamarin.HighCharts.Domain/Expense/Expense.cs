using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.HighCharts.Domain.Expense.Interface;
using Xamarin.HighCharts.InfraStructure.Domain;
using Xamarin.HighCharts.InfraStructure.Domain.Interfaces;
using System.Linq.Expressions;
using System.Reflection;

namespace Xamarin.HighCharts.Domain.Expense
{
    public class Expense : EntityBase<int, Expense>, IExpense, IAggregateRoot
    {


        #region Fields
        private string _description;
        private string _category;
        private string _date;
        private string _value;

        #endregion

        #region Properties
        public string Description
        {
            get { return _description; }
			set { _description = value;   RaisedPropertyChanged(()=> Description); }
        }



        public string Category
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
			if (string.IsNullOrEmpty (Description) || string.IsNullOrEmpty (Category) || string.IsNullOrEmpty (Value) || string.IsNullOrEmpty (Date))
				AddRule (ExpenseBusinessRules.Required);
		



		
			//Category.ThrowExceptionIfInvalid();
		}

		protected override void ValidateWithCriteria (params Expression<Func<Expense, string>>[] properties)
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
