
using Xamarin.HighCharts.Domain.Interfaces;
using Xamarin.HighCharts.InfraStructure.Domain;
using Xamarin.HighCharts.InfraStructure.Domain.Interfaces;
using Xamarin.HighCharts.Domain.Extensions;
using System.Linq.Expressions;
using System;
using System.Reflection;

namespace Xamarin.HighCharts.Domain
{
    public class User : EntityBase<int, User>, IUser, IAggregateRoot
    {

        #region Fields

        private string _name;
        private string _email;
        private string _password;
        private bool _transaction;

        #endregion

        #region Properties

        public string Name      
        {
            get { return _name; }
            set 
            {
                _name = value;
                RaisedPropertyChanged(()=>Name);
            }
        }
        public string Email     
        {
            get { return _email; }
            set 
            {
                _email = value;
                RaisedPropertyChanged(()=>Email);
            }
        }
        public string Password
        {
            get { return _password; }
            set 
            {
                _password = value;
                RaisedPropertyChanged(()=> Password);
            }
        }
        public bool Transaction
        {
            get { return _transaction; }
            set 
            {
                _transaction = value;
                RaisedPropertyChanged(()=> Transaction);
            }
        }

        #endregion

        #region Overridable
        protected override void Validate()
        {
            if (string.IsNullOrEmpty(Name))
                AddRule(UserBusinessRules.NameRequired);

            if (string.IsNullOrEmpty(Email))
                AddRule(UserBusinessRules.EmailRequired);

            if (!Email.IsEmail())
                AddRule(UserBusinessRules.InvalidEmail);

            if (string.IsNullOrEmpty(Password))
                AddRule(UserBusinessRules.PasswordRequired);

            //Category.ThrowExceptionIfInvalid();
        }

        protected override void ValidateWithCriteria(params Expression<Func<User, string>>[] properties)
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
                    else 
                    {
                        if (pInfo.Name.ToLower() == "email") 
                        {
                            if(!value.IsEmail())
                                AddRule(new BusinessRules(string.Format(UserBusinessRules.Invalid.DescriptionRule, pInfo.Name)));
                        }
                    }
                    
                    
                }
            }
        }

        #endregion


        
    }
}
