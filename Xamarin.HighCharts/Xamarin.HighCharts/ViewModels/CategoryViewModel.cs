

using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Highcharts.Domain.ValueObjects;
using Xamarin.HighCharts.Domain.ValueObjects;
using Xamarin.HighCharts.InfraStructure.DependencyService;
using Xamarin.HighCharts.Messages;
using Xamarin.HighCharts.Repository.Database.Interfaces;
using Xamarin.HighCharts.ViewModels.Base;
using Xamarin.HighCharts.ViewModels.Base.Interfaces;
using Xamarin.HighCharts.ViewModels.Interfaces;

namespace Xamarin.HighCharts.ViewModels
{
    public class CategoryViewModel : ViewModelBase<Category>, ICategoryViewModel, ICategoryRepositoryService<Category>
    {

        #region Fields

        private Category _category;
        private Command _saveCommand;

        #endregion

        #region Methods

        public override Category Domain
        {
            get { return _category; }
            set 
            {
                _category = value;
                RaisedPropertyChanged(() => Domain);
            }
        }

        public IValueObjectRepository<Category> Repository
        {
            get { return DependencyResolver.Container.GetService<IValueObjectRepository<Category>>(); }
        }

        #endregion

        #region Constructor

        public CategoryViewModel(INavigation navigation)
			: base(navigation) { }

        #endregion

        #region Commands

        public Command SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand = new Command(async () => await SaveCategoryCommand()));
            }
        }

        
        #endregion

        #region Methods

        protected async Task SaveCategoryCommand()
        {
            var categoryService = DependencyResolver.Container.GetService<ICategoryService>();

            try
            {
                ThrowExceptionIfInvalidDomain(Domain);

                //Service
                var result = categoryService.AddCategory(Domain);

                if (result)
                {
                    //Database
                    Repository.Save(Domain);

                    //TODO .: Use internationalization for messages. 
                    await ActionMessage.DisplayAlert("Success", "Category registered successfully.", "Ok");
                    Renew();
                }
                else
                {
                    await ActionMessage.DisplayAlert("Fail", "Service error.", "Ok");
                }
            }
            catch (Exception invalidDomainException)
            {
                ActionMessage.DisplayAlert("Error", invalidDomainException.Message, "Ok");
            }
        }

        public override void ThrowExceptionIfInvalidDomain(Category domain)
        {
            domain.ThrowExceptionIfInvalid();
        }

        #endregion



    }
}
