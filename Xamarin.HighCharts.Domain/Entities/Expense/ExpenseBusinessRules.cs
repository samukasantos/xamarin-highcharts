using System;
using Xamarin.HighCharts.InfraStructure.Domain;

namespace Xamarin.HighCharts.Domain.Entities
{
	public static class ExpenseBusinessRules
	{
		#region Fields

		//TODO .: Use internationalization for messages.
		public static readonly BusinessRules Required            = new BusinessRules("{0} is required.");
		public static readonly BusinessRules Invalid             = new BusinessRules("{0} is invalid.");
        public static readonly BusinessRules CategoryNotSelected = new BusinessRules("Select a category.");


		#endregion

	}
}

