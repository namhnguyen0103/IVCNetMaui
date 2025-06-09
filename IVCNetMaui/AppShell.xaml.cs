namespace IVCNetMaui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            Routing.RegisterRoute("hub/healthMonitor/systemDetail", typeof(Views.Detail.SystemDetailPage));
            Routing.RegisterRoute("hub/healthMonitor/processDetail", typeof(Views.Detail.ProcessDetailPage));
            Routing.RegisterRoute("eventView/eventDetail", typeof(Views.Detail.EventDetailPage));
            Routing.RegisterRoute("eventView/eventDetail/mediaDetail", typeof(Views.Detail.MediaDetailPage));
            InitializeComponent();
        }
    }
}
