using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.HighCharts.Domain.Entities
{
	public interface IExpense :IDomain
    {

        string Description{ get; set; }
        int Category{ get; set; }
        string Value{ get; set; }
        string Date{ get; set; }
       
    }
}
