using AppUbicua.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppUbicua.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddProductPage : ContentPage
    {
        public AddProductPage()
        {
            InitializeComponent();
            BtnSave.Clicked += BtnSave_Clicked;
            BtnUpdate.Clicked += BtnUpdate_Clicked;
        }

        private async void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            Compra compra = new Compra()
            {
                CompraId = EntId.Text,
                NombreC = EntName.Text,
            };

            var json = JsonConvert.SerializeObject(compra);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();
            var result = await client.PutAsync(string.Concat("https://fnccosmosdbparcialclientecompra.azurewebsites.net/api/UpdateCompra/9"), content);

            if (result.IsSuccessStatusCode)
            {
                await DisplayAlert("Completado", "Compra Modificada", "Aceptar");
            }
        }

        private async void BtnSave_Clicked(object sender, EventArgs e)
        {
            Compra compra = new Compra()
            {
                CompraId = EntId.Text,
                NombreC = EntName.Text,
                NitC = EntNit.Text,
                DescripcionC = EntDesc.Text,
                UbicacionC = EntUbic.Text,
                FechaC = EntFecha.Text,
                TotalC = EntTotal.Text

            };
            var json = JsonConvert.SerializeObject(compra);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();
            var result = await client.PostAsync("https://fnccosmosdbparcialclientecompra.azurewebsites.net/api/CrearCompra", content);

            if(result.StatusCode == HttpStatusCode.Created)
            {
                await DisplayAlert("", "", "");
            }

        }

       
    }
}