using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Xamarin.Forms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChartsF.Pages
{
    public class ChartPageLines : ContentPage
    {
        private string _htmlPagePath = "Xamarin.HighCharts.WebContent.HTML.bar_line.html";
        private string _htmlValue = "_______VALUE_______";

        ListViewPage listViewPage;
        StackLayout stack;
        HtmlWebViewSource htmlSource;
        WebView browser;

        public long ToJsonTicks(DateTime value)
        {
            return (value.ToUniversalTime().Ticks - ((new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).Ticks)) / 10000;
        }
        public ChartPageLines()
        {
            Device.BeginInvokeOnMainThread(() =>
              {
                  LoadData();
              });

        }

        private async void LoadData()
        {
            htmlSource = new HtmlWebViewSource();
        






            var listview = new List<ChartsF.Pages.ListViewPage.Objetos>()
     {
         new ChartsF.Pages.ListViewPage.Objetos("YHOO","-10 %","R$ 10,00","1"),
         new ChartsF.Pages.ListViewPage.Objetos("FB","-10 %","R$ 10,00","2"),
         new ChartsF.Pages.ListViewPage.Objetos("BAC","-10 %","R$ 10,00","3"),
         new ChartsF.Pages.ListViewPage.Objetos("INTC","-10 %","R$ 10,00","3"),
         new ChartsF.Pages.ListViewPage.Objetos("AAPL","-10 %","R$ 10,00","3"),
         
     };

            htmlSource.SetBinding(HtmlWebViewSource.HtmlProperty, "HtmlContent.PageContent");


            stack = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Padding = new Thickness(8)
            };

            var activity = new ActivityIndicator
            {
                Color = Color.Blue,
                IsEnabled = true
            };
            activity.SetBinding(ActivityIndicator.IsVisibleProperty, "IsBusy");
            activity.SetBinding(ActivityIndicator.IsRunningProperty, "IsBusy");

            stack.Children.Add(activity);

            var listViewItem = new ListView();

            listViewItem.ItemsSource = listview;



            var titleList = new Label
            {
                HorizontalOptions = LayoutOptions.Fill,
                Text = "Itens"
            };

            listViewItem.ItemTemplate = new DataTemplate(typeof(LayoutCotacaoCell));
            //Define item selecionado
           
            stack.Children.Add(titleList);
            stack.Children.Add(listViewItem);

            GenerateGraphics(GetItem1(), listViewPage);
        }


        public List<string> GetItem1()
        {
            var valueJson = new List<string>();
           

                valueJson.Add("[" + ToJsonTicks(DateTime.Now.Date.AddMonths(-4).Date) + ",200.50]");
                valueJson.Add("[" + ToJsonTicks(DateTime.Now.Date.AddMonths(-3).Date) + ",100.50]");
                valueJson.Add("[" + ToJsonTicks(DateTime.Now.Date.AddMonths(-2).Date) + ",90.50]");
                valueJson.Add("[" + ToJsonTicks(DateTime.Now.Date.AddMonths(-1).Date) + ",200.50]");

         
           
            return valueJson;
        }

        public List<string> GetItem2()
        {
            var valueJson = new List<string>();


            valueJson.Add("[" + ToJsonTicks(DateTime.Now.Date.AddMonths(-4).Date) + ",200.50]");
            valueJson.Add("[" + ToJsonTicks(DateTime.Now.Date.AddMonths(-3).Date) + ",1000.50]");
            valueJson.Add("[" + ToJsonTicks(DateTime.Now.Date.AddMonths(-2).Date) + ",90.50]");
            valueJson.Add("[" + ToJsonTicks(DateTime.Now.Date.AddMonths(-1).Date) + ",210.50]");

            return valueJson;
        }

        public List<string> GetItem3()
        {
            var valueJson = new List<string>();


            valueJson.Add("[" + ToJsonTicks(DateTime.Now.Date.AddMonths(-4).Date) + ",80.50]");
            valueJson.Add("[" + ToJsonTicks(DateTime.Now.Date.AddMonths(-3).Date) + ",20.50]");
            valueJson.Add("[" + ToJsonTicks(DateTime.Now.Date.AddMonths(-2).Date) + ",82.50]");
            valueJson.Add("[" + ToJsonTicks(DateTime.Now.Date.AddMonths(-1).Date) + ",12.50]");
            return valueJson;
        }

        public void GenerateGraphics(List<string> valueUpdate, ListViewPage listViewPage)
        {




            browser = new MyWebView
            {
                BackgroundColor = Color.Red,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = 600
            };




            var list = new ListView
            {
                Header = "Plain text header",
                Footer = "Plain text footer"
            };

            var listStackLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { list }
            };
            var label = new Label
            {
                Text = "Hello from Code!",
                IsVisible = true,

                Opacity = 0.75,
                XAlign = TextAlignment.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                TextColor = Color.Blue,
                BackgroundColor = Color.FromRgb(255, 128, 128),
                FontSize = Device.GetNamedSize(NamedSize.Large, new Label()),
                FontAttributes = FontAttributes.Bold | FontAttributes.Italic
            };









            browser.Source = htmlSource;
            htmlSource.Html = GenerateHTML(valueUpdate);




            Content = null;
            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children =
                          {
                              
                              browser,
                              stack
                             
                          },
                Spacing = 10,
            };



        }

        public string GenerateHTML(List<string> valueUpdate)
        {
            var assembly = typeof(LayoutCotacaoCell).GetTypeInfo().Assembly;

            //Get html text string
            string htmlTextString = GetStringResource(assembly, _htmlPagePath);

            //Replace the javascript method into the html
            string jsTextString = string.Empty;

            jsTextString += GetStringResource(assembly, "Xamarin.HighCharts.WebContent.HTML.js.highstock.js");
            jsTextString += GetStringResource(assembly, "Xamarin.HighCharts.WebContent.HTML.js.modules.exporting.js");


            string value = GetStringResource(assembly, _htmlPagePath);
            string values = "[" + string.Join(",", valueUpdate) + "]";

            value = value.Replace(_htmlValue, values);
            value = value.Replace("___METHODSJS___", jsTextString);

            return value;

        }
        private static string GetStringResource(Assembly assembly, string resourcePath)
        {
            Stream stream = assembly.GetManifestResourceStream(resourcePath);
            string returnString = "";
            using (var reader = new System.IO.StreamReader(stream))
            {
                returnString = reader.ReadToEnd();
            }
            return returnString;
        }

    }
}


