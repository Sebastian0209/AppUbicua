namespace AppUbicua.Infrastructure
{
    using ViewModels;
  
    public class InstanceLocator
    {
        #region Properties
        public MainViewModel Main 
        { 
            get; set; 
        }
        #endregion

        #region Constructors

        public InstanceLocator()
        {
            this.Main = new MainViewModel(); // sirve para ligar login a viewModel

        }
        #endregion
    }
}
