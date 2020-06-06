

namespace AppUbicua.ViewModels
{
    using AppUbicua.Services;
   
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Xamarin.Forms;
    using System;
    using AppUbicua.Models;
    using System.Collections.ObjectModel;

    public class AddProductViewModel : BaseViewModel
    {
        private bool isRunning;
        private bool isEnabled;
        private readonly ApiService apiService;
        private ObservableCollection<Compra> compras;
        public ObservableCollection<Compra> Compras
        {
            get { return this.compras; }
            set { SetValue(ref this.compras, value); }
        }

        public bool IsRunnung
        {
            get => this.isRunning;
            set => this.SetValue(ref this.isRunning, value);
        }
        public bool IsEnabled
        {
            get => this.isEnabled;
            set => this.SetValue(ref this.isEnabled, value);
        }

        public string CompraId { get; set; }
        public string NombreC { get; set; }
        public string NitC { get; set; }
        public string DescripcionC { get; set; }
        public string UbicacionC { get; set; }
        public string FechaC { get; set; }
        public string TotalC { get; set; }

        public ICommand SaveCommand => new RelayCommand(this.Save);

        public AddProductViewModel()
        {
            this.apiService = new ApiService();
            this.IsEnabled = true;
        }

        private async void Save()
        {
            if (string.IsNullOrEmpty(this.CompraId))  // SI EMAIL ESTA VACIO
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error", //Titulo de alerta
                    "Ingrese Id de Compra",
                    "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(this.NombreC))  // SI EMAIL ESTA VACIO
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error", //Titulo de alerta
                    "Ingrese Nombre de Cliente",
                    "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(this.NitC))  // SI EMAIL ESTA VACIO
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error", //Titulo de alerta
                    "Ingrese Nit",
                    "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(this.DescripcionC))  // SI EMAIL ESTA VACIO
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error", //Titulo de alerta
                    "Ingrese la Descripcion",
                    "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(this.UbicacionC))  // SI EMAIL ESTA VACIO
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error", //Titulo de alerta
                    "Ingrese su Ubicacion",
                    "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(this.FechaC))  // SI EMAIL ESTA VACIO
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error", //Titulo de alerta
                    "Ingrese la fecha",
                    "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(this.TotalC))  // SI EMAIL ESTA VACIO
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error", //Titulo de alerta
                    "Ingrese el monto total",
                    "Aceptar");
                return;
            }
            this.IsRunnung = true;
            this.IsEnabled = false;

            var compra = new Compra
            {
                CompraId = this.CompraId,
                NombreC = this.NombreC,
                NitC = this.NitC,
                DescripcionC = this.DescripcionC,
                UbicacionC = this.UbicacionC,
                FechaC = this.FechaC,
                TotalC = this.TotalC
            };

            var url = Application.Current.Resources["https://fnccosmosdbparcialclientecompra.azurewebsites.net/"].ToString();
            var response = await this.apiService.Post(
                url,
                "/api",
                "/CrearCompra",
                compra);
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                return;
            }

            var newProduct = (Compra)response.Result;
            MainViewModel.GetInstance().Compras.Compras.Add(newProduct);

            this.IsRunnung = false;
            this.IsEnabled = true;
            await App.Navigator.PopAsync();

        }
    }
}
