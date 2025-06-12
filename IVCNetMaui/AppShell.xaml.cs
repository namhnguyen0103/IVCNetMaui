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
            Routing.RegisterRoute("hub/healthMonitor/systemDetail", typeof(Views.Detail.SystemDetailPage));
            Routing.RegisterRoute("hub/healthMonitor/processDetail", typeof(Views.Detail.ProcessDetailPage));
            Routing.RegisterRoute("eventView/eventDetail", typeof(Views.Detail.EventDetailPage));
            Routing.RegisterRoute("eventView/eventDetail/mediaDetail", typeof(Views.Detail.MediaDetailPage));
        }
    }
}
