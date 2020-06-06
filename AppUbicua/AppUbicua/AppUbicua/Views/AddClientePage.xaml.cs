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
    public partial class AddClientePage : ContentPage
    {
        public AddClientePage()
        {
            InitializeComponent();
            BtnSave.Clicked += BtnSave_Clicked;
        }

        private async void BtnSave_Clicked(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente()
            {
                ClienteId = EntId.Text,
                NombreCli = EntName.Text,
                NitCli = EntNit.Text,
                CelularCli = EntCel.Text,
                UbicacionCli = EntUbic.Text,
                FechaCli = EntFecha.Text,
                CorreoCli = EntCorreo.Text

            };
            var json = JsonConvert.SerializeObject(cliente);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();
            var result = await client.PostAsync("https://fnccosmosdbparcialclientecompra.azurewebsites.net/api/ClienteInsert", content);

            if (result.StatusCode == HttpStatusCode.Created)
            {
                await DisplayAlert("Alert", "Created", "Cliente");
            }
        }
    }
}