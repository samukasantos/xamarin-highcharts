using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChartsF.Pages
{
    public class LayoutCotacaoCell : ViewCell
    {

      

        public LayoutCotacaoCell()
        {
         
            var nameLayout = CreateNameLayout();

            var viewLayout = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                Children = {  nameLayout }
            };
            View = viewLayout;
        }

        static StackLayout CreateNameLayout()
        {

            var nameLabel = new Label
            {
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            nameLabel.SetBinding(Label.TextProperty, "Produto");

            var Valor = new Label
            {
                HorizontalOptions = LayoutOptions.End,
                XAlign = TextAlignment.Center,
                WidthRequest = 100,
                BackgroundColor = Color.FromHex("1a1c20"),
                TextColor = Color.White,
            
            };
            Valor.SetBinding(Label.TextProperty, "Valor");
            var Variacao = new Label
            {
                HorizontalOptions = LayoutOptions.End,
                XAlign = TextAlignment.Center,
                WidthRequest = 100,
            };

            Variacao.SetBinding(Label.TextProperty, "Variacao");

            var nameLayout = new StackLayout()
            {
                Spacing = 20, // <- Very important!!
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Horizontal,
                Padding = new Thickness(8)
             
              
            };
            nameLayout.Children.Add(nameLabel);
            nameLayout.Children.Add(Variacao);
            nameLayout.Children.Add(Valor);
            return nameLayout;
        }

    }
}
