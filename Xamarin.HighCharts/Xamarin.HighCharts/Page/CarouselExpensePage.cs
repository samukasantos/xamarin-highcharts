using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xamarin.HighCharts.Page
{
    public class CarouselExpensePage : CarouselPage
    {

        public CarouselExpensePage()
        {
            this.Children.Add(new ExpensePage());
            this.Children.Add(new ListViewExpensePage());

        }

        protected override void SetupContent(ContentPage content, int index)
        {
            base.SetupContent(content, index);
        }
    }
}
