using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.HighCharts.Domain.Entities;
using Xamarin.HighCharts.InfraStructure.DependencyService;
using Xamarin.HighCharts.ViewModels.Base;
using Xamarin.HighCharts.ViewModels.Interfaces;

namespace Xamarin.HighCharts.ViewModels
{
	public class ExpendViewModel: ViewModelBase<Expense>, IExpenseViewModel, IExpenseRepositoryService
    {

		#region Constructor

		public ExpendViewModel(INavigation navigation)
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

		public IExpenseRepositoryService Repository {
			get {
				throw new NotImplementedException ();
			}
		}

		public Xamarin.HighCharts.InfraStructure.UnitWork.IUnitWork UnitWork {
			get {
				throw new NotImplementedException ();
			}
		}

		#endregion

		public Xamarin.Forms.Command SaveCommand {
			get {
				throw new NotImplementedException ();
			}
		}
    }
}
