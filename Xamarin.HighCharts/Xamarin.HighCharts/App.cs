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
            WCFHighChartsServiceClient webService = new WCFHighChartsServiceClient();

          /*  User user = new User();
            user.ID = 10;
            user.Login = "highcharts";
            user.Password = "123";
            user.Email = "charts@charts.com";

            webService.AddUserAsync(user);
            webService.GetUsersCompleted += webService_GetUsersCompleted;
            webService.GetUsersAsync();*/
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

        static void webService_GetUsersCompleted(object sender, GetUsersCompletedEventArgs e)
        {
            var itens = e.Result;
        }








    }
}
