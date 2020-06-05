namespace AppUbicua.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Views;

    public class LoginViewModel : BaseViewModel
    {


        #region Attributes
        private string email;
        private string password;
        private bool isRunning;
        private bool isEnabled;

        #endregion

        #region Properties
        public string Email
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }
        public string Password
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }
        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }
        public bool IsRemembered
        {
            get; set;
        }
        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }
        #endregion



        #region Constructors
        public LoginViewModel()
        {
            this.IsRemembered = true;
            this.isEnabled = true;

            this.Email = "carlos@gmail.com";
            this.Password = "12345";

        }

        #endregion

        #region Commands
        public ICommand LoginCommand 
        {
            get
            {
                return new RelayCommand(Login);
            }  
        
        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))  // SI EMAIL ESTA VACIO
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error", //Titulo de alerta
                    "Ingrese su Email", 
                    "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(this.Password))  // SI EMAIL ESTA VACIO
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error", //Titulo de alerta
                    "Ingrese su Password",
                    "Aceptar");
                return;
            }
            
            this.IsRunning = true;
            this.IsEnabled = false;

            this.Email = string.Empty;
            this.Password = string.Empty;

            MainViewModel.GetInstance().Products = new ComprasViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new ComprasPage());

           

        }
        #endregion
    }
}
