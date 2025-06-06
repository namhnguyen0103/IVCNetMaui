namespace IVCNetMaui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            Routing.RegisterRoute("hub/healthMonitor/systemDetail", typeof(Views.Detail.SystemDetailPage));
            Routing.RegisterRoute("hub/healthMonitor/processDetail", typeof(Views.Detail.ProcessDetailPage));
            InitializeComponent();
        }
    }
}
