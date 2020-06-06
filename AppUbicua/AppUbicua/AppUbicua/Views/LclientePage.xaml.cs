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
    public partial class LclientePage : ContentPage
    {
        public LclientePage()
        {
            InitializeComponent();
            GetCliente();
        }

        private async void GetCliente()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("https://fnccosmosdbparcialclientecompra.azurewebsites.net/api/FuncionGetCliente/12");
            var compras = JsonConvert.DeserializeObject<List<Cliente>>(response);


            ClientesListView.ItemsSource = compras;
        }
    }
}