

using AppUbicua.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AppUbicua.ViewModels
{
    public class MainViewModel
    {
        #region ViewModels
        public LoginViewModel Login { get; set; }
        public ComprasViewModel Products { get; set; }

        public ObservableCollection<MenuItemViewModel> Menus { get; set; }

        #endregion

        #region Constructors
        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
            this.LoadMenus();
        }

        private void LoadMenus()
        {
            
            var menus = new List<Menu>
            {
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
