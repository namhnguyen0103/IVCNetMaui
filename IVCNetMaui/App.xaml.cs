using IVCNetMaui.Services.Navigation;
using IVCNetMaui.Views;

namespace IVCNetMaui
{
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;
        public App(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var loginPage = _serviceProvider.GetRequiredService<LoginPage>();
            return new Window(loginPage);
        }
    }
}