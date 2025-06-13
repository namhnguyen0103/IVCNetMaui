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
            Routing.RegisterRoute("dashboard/hubHealthMonitor", typeof(Views.Dashboard.HubHealthMonitorPage));
            Routing.RegisterRoute("dashboard/hubHealthMonitor/systemDetail", typeof(Views.Detail.SystemDetailPage));
            Routing.RegisterRoute("dashboard/hubHealthMonitor/processDetail", typeof(Views.Detail.ProcessDetailPage));
            Routing.RegisterRoute("dashboard/edgeUnit", typeof(Views.Dashboard.EdgeUnitPage));
            Routing.RegisterRoute("eventView/eventDetail", typeof(Views.Detail.EventDetailPage));
            Routing.RegisterRoute("eventView/eventDetail/mediaDetail", typeof(Views.Detail.MediaDetailPage));
        }
    }
}
