
namespace AppUbicua.ViewModels
{
    using AppUbicua.Models;
    using AppUbicua.Services;
    using GalaSoft.MvvmLight.Command;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class ComprasViewModel : BaseViewModel
    {
        #region Services

        #endregion

        #region Attributes
       
        #endregion
        #region Properties
        public ObservableCollection<Product> Products
        {
            get; 
            set ;
        }
    

        #endregion

        #region Contructors
        public ComprasViewModel()
        {
            Products = new ObservableCollection<Product>
            {
            new Product
            {
                Name = "Iphone 11 pro max",
                Price = 1250.0m,
                Image= "iphone.png",
                HasOffer = false

            },

            new Product
            {
                Name = "AirPods Pro",
                Price = 190.0m,
                Image= "airpods.png",
                HasOffer = false

            },
              new Product
            {
                Name = "Mac Book Pro",
                Price = 2500.0m,
                Image= "macbook.png",
                HasOffer = false

            },
            
            };
            
        }
    

        #endregion

        #region Methods
       
        #endregion

        #region Commands
    
        #endregion  
    }
}
