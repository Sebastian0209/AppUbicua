

namespace AppUbicua
{
    using AppUbicua.ViewModels;
    using AppUbicua.Views;
    using Xamarin.Forms;

    public partial class App : Application
    {
        #region Constructors
        public App()
        {
            InitializeComponent();
            MainViewModel.GetInstance().Login = new LoginViewModel();
            this.MainPage = new NavigationPage(new LoginPage());
        }
        #endregion

        #region Methods
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
        #endregion
    }
}
