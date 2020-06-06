using AppUbicua.Views;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppUbicua.ViewModels
{
    public class MenuItemViewModel : AppUbicua.Models.Menu
    {
        public ICommand SelectMenuCommand { get { return new RelayCommand(this.SelectMenu); } }

        private async void SelectMenu()
        {
            App.Master.IsPresented = false;
            var mainViewModel = MainViewModel.GetInstance();
            switch (this.PageName)
            {
                case "LclientePage":
                    await App.Navigator.PushAsync(new LclientePage());
                    break;
                case "LcomprasPage":
                    await App.Navigator.PushAsync(new LcomprasPage());
                    break;
                default:
                    MainViewModel.GetInstance().Login = new LoginViewModel();
                    Application.Current.MainPage = new NavigationPage(new LoginPage());
                    break;
            }
        }
    }
}
