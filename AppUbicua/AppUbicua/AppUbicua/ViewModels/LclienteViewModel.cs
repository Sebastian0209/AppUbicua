using AppUbicua.Models;
using AppUbicua.Services;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppUbicua.ViewModels
{
    public class LclienteViewModel : BaseViewModel
    {
        #region Services

        private ApiService apiService;
        #endregion


        #region Attributes

        private ObservableCollection<Cliente> clientes;
        private bool isRefreshing;
        #endregion


        #region Properties
        public ObservableCollection<Cliente> Clientes
        {
            get { return this.clientes; }
            set { SetValue(ref this.clientes, value); }
        }

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }
        #endregion



        #region Constructors

        public LclienteViewModel()
        {
            this.apiService = new ApiService();
            this.LoadLands();
        }

        #endregion


        #region Methods
        private async void LoadLands()
        {
            var response = await this.apiService.GetListAsync<Cliente>(
                "http/fnccosmosdbparcialclientecompra.azurewebsites.net",
                "/api",
                "/FuncionGetCliente/1"
                );
            if (!response.IsSuccess)
            {

                await Application.Current.MainPage.DisplayAlert(
                    "Error", response.Message,
                    "Aceptar");
                return;
            }
            var list = (List<Cliente>)response.Result;
            this.Clientes = new ObservableCollection<Cliente>(list);

        }
        #endregion

        #region Commands
        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadLands);

            }
        }
        #endregion
    }
}
