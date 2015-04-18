using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChartsF.Pages
{
    public class ListViewPage : ContentPage
    {

        public ListView listViewItem;

        public class Objetos
        {
            public Objetos(string ultimoPreco, string variacao, string Valor, string key)
            {
             
                this.UltimoPreco = ultimoPreco;
                this.Variacao = variacao;
                this.Valor = Valor;

            }

          
            public string UltimoPreco { private set; get; }

            public string Variacao { private set; get; }

            public string Valor { private set; get; }


        };

     
    }
}
