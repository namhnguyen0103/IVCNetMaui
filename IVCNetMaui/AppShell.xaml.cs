using IVCNetMaui.Services.Navigation;

namespace IVCNetMaui
{
    public partial class AppShell : Shell
    {
        private readonly INavigationService _navigationService;
        public AppShell(INavigationService navigationService)
        {
            _navigationService = navigationService;
            AppShell.InitializeRouting();
            
            InitializeComponent();
        }

        private static void InitializeRouting() 
        { 
            Routing.RegisterRoute("dashboard/healthMonitor", typeof(Views.Dashboard.HealthMonitorPage));
            Routing.RegisterRoute("dashboard/edgeDetail", typeof(Views.Detail.EdgeDetailPage));
            Routing.RegisterRoute("dashboard/edgeDetail/healthMonitor", typeof(Views.Dashboard.HealthMonitorPage));
            Routing.RegisterRoute("eventView/eventDetail", typeof(Views.Detail.EventDetailPage));
            Routing.RegisterRoute("eventView/eventDetail/mediaDetail", typeof(Views.Detail.MediaDetailPage));
        }

        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            _navigationService.NavigateToAsync("//login");
        }
    }
}
