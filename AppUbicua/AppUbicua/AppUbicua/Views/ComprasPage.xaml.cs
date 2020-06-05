using AppUbicua.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppUbicua.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    
    public partial class ComprasPage : ContentPage
    {
        public ComprasPage()
        {
            InitializeComponent();
            BindingContext = new ComprasViewModel();
        }
    }
}