
using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.HighCharts.Domain;
using Xamarin.HighCharts.Page.Interfaces;
using Xamarin.HighCharts.ViewModels.Base.Interfaces;

namespace Xamarin.HighCharts.ViewModels.Base
{
    public abstract class ViewModelBase<T> : INotifyPropertyChanged, IViewModel
        where T : IDomain, new()
    {
        #region Fields  

        private INavigation _inavigation;

        #endregion  

        #region Properties

        public virtual T Domain { get; set; }

        public INavigation Navigation
        {
            get { return _inavigation; }
        }

        public IActionMessage ActionMessage { get; set; }

        #endregion

        #region Constructor

        public ViewModelBase(INavigation navigation)
        {
            Domain       = new T();
            _inavigation = navigation;
        }
        
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged; 
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

        public abstract void ThrowExceptionIfInvalidDomain(T domain);

        #endregion

    }
}
