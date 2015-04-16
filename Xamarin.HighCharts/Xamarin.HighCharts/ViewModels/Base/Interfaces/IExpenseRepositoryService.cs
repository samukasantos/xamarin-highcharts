using System;
using Xamarin.HighCharts.InfraStructure.UnitWork;

namespace Xamarin.HighCharts
{
	public interface IExpenseRepositoryService
	{
		IExpenseRepositoryService Repository { get; }
		IUnitWork UnitWork         { get; }
	}
}

