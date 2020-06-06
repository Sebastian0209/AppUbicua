using AppUbicua.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppUbicua.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LcomprasPage : ContentPage
    {
        public LcomprasPage()
        {
            InitializeComponent();
            GetCompras();   

        }

        private async void GetCompras()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("https://fnccosmosdbparcialclientecompra.azurewebsites.net/api/FuncionGetCompra/12");
            var compras = JsonConvert.DeserializeObject<List<Compra>>(response);

            CompraListView.ItemsSource = compras;
        }
    }
}