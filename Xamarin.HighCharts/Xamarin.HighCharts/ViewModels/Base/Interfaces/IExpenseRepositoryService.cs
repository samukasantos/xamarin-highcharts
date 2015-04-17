using System;
using Xamarin.HighCharts.InfraStructure.UnitWork;
using Xamarin.HighCharts.Domain.Entities;

namespace Xamarin.HighCharts
{
	public interface IExpenseRepositoryService
	{
		IExpenseRepository Repository { get; }
		IUnitWork UnitWork         { get; }
	}
}

