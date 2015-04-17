using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.HighCharts.Domain.Entities;
using Xamarin.HighCharts.InfraStructure.DependencyService;
using Xamarin.HighCharts.ViewModels.Base;
using Xamarin.HighCharts.ViewModels.Interfaces;
using Xamarin.HighCharts.InfraStructure.UnitWork;

namespace Xamarin.HighCharts.ViewModels
{
	public class ExpenseViewModel: ViewModelBase<Expense>, IExpenseViewModel, IExpenseRepositoryService
    {

		#region Fields

		private Expense _expense;
		private Command _saveCommand;

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

		#endregion

		#region Constructor

		public ExpenseViewModel(INavigation navigation)
			: base(navigation) { }

		#endregion

		#region Methods

		protected async Task SaveUserCommand()
		{
			var expenseService = DependencyResolver.Container.GetService<IExpenseService>();

			try
			{
				ThrowExceptionIfInvalidDomain(Domain);

				//Service
			//	var result = userService.AddUser(Domain);

			/*	if (result)
				{
					//Database
					Repository.Save(Domain);
					UnitWork.Commit();

					//TODO .: Use internationalization for messages. 
					await ActionMessage.DisplayAlert("Success", "Expense registered successfully.", "Ok");
				}
				else
				{
					await ActionMessage.DisplayAlert("Fail", "Service error.", "Ok");
				}*/
			}
			catch (Exception invalidDomainException)
			{
				ActionMessage.DisplayAlert("Error", invalidDomainException.Message, "Ok");
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
		#region IExpenseRepositoryService implementation

		public IExpenseRepository Repository {
			get {
				  return DependencyResolver.Container.GetService<IExpenseRepository> ();
			}
		}

		public Xamarin.HighCharts.InfraStructure.UnitWork.IUnitWork UnitWork {
			get {
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

		#endregion

		#region Methods

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
					await ActionMessage.DisplayAlert("Success", "User registered successfully.", "Ok");
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

		/*public override void ThrowExceptionIfInvalidDomain(Expense domain)
		{
			var rules = domain.GetBrokenRules( c => c.Description, c => c.Date, c => c.Value);
			if (rules.Any()) 
			{
				foreach (var rule in rules)
					throw new Exception(rule.DescriptionRule);
			}
		}*/

		#endregion

    }
}
