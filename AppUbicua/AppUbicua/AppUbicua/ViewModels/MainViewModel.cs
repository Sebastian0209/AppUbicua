

using AppUbicua.Models;
using AppUbicua.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace AppUbicua.ViewModels
{
    public class MainViewModel
    {
        #region ViewModels
        public LoginViewModel Login { get; set; }
        public ComprasViewModel Products { get; set; }
        public LclienteViewModel Clientes { get; set; }

        public AddProductViewModel Compras { get; set; }

        public AddProductViewModel AddProduct { get; set; }

        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        //public ICommand AddProductCommand { get { return new RelayCommand(this.GoAddProduct); }  }

    

        public ObservableCollection<MenuItemViewModel> Menus { get; set; }
         
        #endregion

        #region Constructors
        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
            this.LoadMenus();
        }

       // private async void GoAddProduct()
        //{
          //  this.AddProduct = new AddProductViewModel();
            //await App.Navigator.PushAsync(new AddProductPage());

        //}

        private void LoadMenus()
        {
            
            var menus = new List<Menu>
            {
                new Menu
                {
                    Icon="ic_add_shopping_cart",
                    PageName="AddProductPage",
                    Title="Add Compra"
                },
                new Menu
                {
                    Icon="ic_person_add",
                    PageName="AddClientePage",
                    Title="Add Cliente"
                },
                new Menu
                {
                    Icon="ic_supervised_user_circle",
                    PageName="LclientePage",
                    Title="Lista de Clientes"
                },
                new Menu
                {
                    Icon="ic_content_paste",
                    PageName="LcomprasPage",
                    Title="Lista de Compras"
                },
                 new Menu
                {
                    Icon="ic_exit_to_app",
                    PageName="LoginPage",
                    Title="Salir"
                }

            };
            this.Menus = new ObservableCollection<MenuItemViewModel>(
                menus.Select(m => new MenuItemViewModel
                {
                    Icon = m.Icon,
                    PageName = m.PageName,
                    Title = m.Title
                }).ToList());
        }
        #endregion

        #region Singleton
        private static MainViewModel instance;
        public static MainViewModel GetInstance()
        {
            if(instance == null)
            {
                return new MainViewModel();
            }
            return instance;
        }
        #endregion
    }
}
