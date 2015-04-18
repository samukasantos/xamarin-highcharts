using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.HighCharts.Domain.Entities;
using Xamarin.HighCharts.InfraStructure.DependencyService;
using Xamarin.HighCharts.ViewModels.Base;
using Xamarin.HighCharts.ViewModels.Interfaces;
using Xamarin.HighCharts.InfraStructure.UnitWork;
using Xamarin.HighCharts.Utils;
using System.Collections.Generic;
using Xamarin.Highcharts.Domain.ValueObjects;
using System.Collections.ObjectModel;
using Xamarin.HighCharts.Repository.Database.Interfaces;
using Xamarin.HighCharts.Domain.ValueObjects;
using Xamarin.HighCharts.InfraStructure.Domain;

namespace Xamarin.HighCharts.ViewModels
{
	public class ExpenseViewModel: ViewModelBase<Expense>, IExpenseViewModel, IExpenseRepositoryService
    {

		#region Fields

		private Expense _expense;
		private Command _saveCommand;
        private Command _categoriesCommand;
        private ObservableCollection<CodeValue> _categories;
        private bool _categoryVisibility;
        private string _categorySelectedTitle;

		#endregion

		#region Properties

		public override Expense Domain
		{
			get
			{
				return _expense;
			}
			set
			{
				_expense = value;
				RaisedPropertyChanged(() => Domain);
			}
		}

        public bool CategoryVisibility
		{
			get
			{
                return _categoryVisibility;
			}
			set
			{
                _categoryVisibility = value;
                RaisedPropertyChanged(() => CategoryVisibility);
			}
		}

        public ObservableCollection<CodeValue> Categories 
        {
            get { return _categories; }
            set 
            {
                _categories = value;
                RaisedPropertyChanged(() => Categories);
            }
        }

        public IValueObjectRepository<Category> CategoryRepository
        {
            get
            {
                 return DependencyResolver.Container.GetService<IValueObjectRepository<Category>>();
            }
        }

        public string CategorySelectedTitle
        {
            get 
            {
                return _categorySelectedTitle; 
            }

            private set 
            {
                _categorySelectedTitle = value;
                RaisedPropertyChanged(() => CategorySelectedTitle);
            }
        }

		#endregion

		#region Constructor

		public ExpenseViewModel(INavigation navigation)
			: base(navigation) 
        {
            Domain.Date = DateTime.Now;
            LoadCategories();
        }

		#endregion

		#region Methods

        private void LoadCategories() 
        {
            if (CategoryRepository != null)
            {
                Categories = new ObservableCollection<CodeValue>
                    (
                        ((ICategoryRepository)CategoryRepository)
                        .FindAll()
                        .Select(c => new CodeValue 
                                        {
                                            Code  = c.Id.ToString(),
                                            Value = c.Description
                                        })
                    );
                CategoryVisibility =  !Categories.Any() ? false : true;
            }
        }

		
		public override void ThrowExceptionIfInvalidDomain(Expense domain)
		{
			var rules = domain.GetBrokenRules( c => c.Category, c => c.Date, c => c.Value, c => c.Description);
			if (rules.Any()) 
			{
				foreach (var rule in rules)
					throw new Exception(rule.DescriptionRule);
			}
		}

		#endregion

		#region IExpenseRepositoryService members

		public IExpenseRepository Repository 
        {
			get 
            {
				  return DependencyResolver.Container.GetService<IExpenseRepository>();
			}
		}

		public IUnitWork UnitWork 
        {
			get 
            {
				return DependencyResolver.Container.GetService<IUnitWork>(); 
			}
		}

		#endregion

		#region Commands

		public Command SaveCommand
		{
			get
			{
				return _saveCommand ?? (_saveCommand = new Command(async () => await SaveExpenseCommand()));
			}
		}

        public Command CategoriesCommand
        {
            get 
            {
                return _categoriesCommand ?? (_categoriesCommand = new Command<CodeValue>(async (c) => { await CategoryCommand(c); }));
            }
        }

		#endregion

		#region Methods

        protected async Task CategoryCommand(CodeValue codeValue)
        {
            if (codeValue != null) 
            {
                var category = DependencyResolver.Container.GetService<ICategory>();

                ((ValueObject)category).Id = int.Parse(codeValue.Code);
                category.Description       = codeValue.Value;

                Domain.Category = category;
            }
        }

		protected async Task SaveExpenseCommand()
		{
			var expenseService = DependencyResolver.Container.GetService<IExpenseService>();

			try
			{
				ThrowExceptionIfInvalidDomain(Domain);

				//Service
				var result = expenseService.AddExpense(Domain);

				if (result)
				{
					//Database
					Repository.Save(Domain);
					UnitWork.Commit();

					//TODO .: Use internationalization for messages. 
					await ActionMessage.DisplayAlert("Sucesso", "Despesas cadastradas com sucesso.", "Ok");
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

        public override void Renew()
        {
            base.Renew();

            Domain.Date           = DateTime.Now;
            CategorySelectedTitle = string.Empty;
        }

		#endregion

    }
}
