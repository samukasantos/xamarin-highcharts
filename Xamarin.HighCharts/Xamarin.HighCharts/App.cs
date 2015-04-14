using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using Xamarin.HighCharts.Services.WCFHighChartsService;

namespace Xamarin.HighCharts
{

    public class App
    {


        public static Page GetMainPage()
        {
           /*   WCFHighChartsServiceClient webService = new WCFHighChartsServiceClient();
         
            User user = new User();
            user.ID = 1;
            user.Login = "highcharts";
            user.Password = "123";
            user.Name = "charts";
         
            webService.AddUserAsync(user);
            webService.DeleteUserAsync(user.ID);*/
            return new ContentPage
            {
                Content = new Label
                {
                    Text = "Hello, Forms !",
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                },
            };

        
        }

      




    }
}
