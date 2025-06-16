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
            Routing.RegisterRoute("dashboard/edgeUnit", typeof(Views.Dashboard.EdgeUnitPage));
            Routing.RegisterRoute("eventView/eventDetail", typeof(Views.Detail.EventDetailPage));
            Routing.RegisterRoute("eventView/eventDetail/mediaDetail", typeof(Views.Detail.MediaDetailPage));
        }
    }
}
