using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.HighCharts.Domain.Expense.Interface
{
	public interface IExpense :IDomain
    {

        string Description{ get; set; }

        string Category{ get; set; }

        string Value{ get; set; }

        string Date{ get; set; }
    }
}
