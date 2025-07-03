using IVCNetMaui.Services.Navigation;
using IVCNetMaui.Views;
using IVCNetMaui.Views.Dashboard;
using IVCNetMaui.Views.Historical;
using IVCNetMaui.Views.View;
using UraniumUI.Icons.MaterialSymbols;

namespace IVCNetMaui
{
    public partial class AppShell : Shell
    {
        private readonly IServiceProvider _serviceProvider;
        public AppShell(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            var dashboard = new FlyoutItem
            {
                Title = "Dashboard",
                Route = "dashboard",
                FlyoutIcon = GetIcon(MaterialSharp.Dashboard),
                Items =
                {
                    new ShellContent
                    {
                        Title = "Hub",
                        ContentTemplate = new DataTemplate(typeof(DashboardMainPage))
                    }
                }
            };

            var cameraView = new FlyoutItem
            {
                Title = "Camera View",
                Route = "cameraView",
                FlyoutIcon = GetIcon(MaterialSharp.Videocam),
                Items =
                {
                    new ShellContent
                    {
                        Title = "Camera View",
                        ContentTemplate = new DataTemplate(typeof(CameraPage))
                    }
                }
            };
            
            var eventView = new FlyoutItem
            {
                Title = "Event View",
                Route = "eventView",
                FlyoutIcon = GetIcon(MaterialSharp.Flag),
                Items =
                {
                    new ShellContent
                    {
                        Title = "Event View",
                        ContentTemplate = new DataTemplate(typeof(EventPage))
                    }
                }
            };

            var historicalTab = new Tab
            {
                FlyoutIcon = GetIcon(MaterialSharp.History),
                Items = 
                {
                    new ShellContent
                    {
                        Title = "Health Data",
                        Route = "healthData",
                        ContentTemplate = new DataTemplate(typeof(HistoricalHealthDataPage))
                    },
                    new ShellContent
                    {
                        Title = "IoT Data",
                        Route = "iotData",
                        ContentTemplate = new DataTemplate(typeof(IoTDataPage))
                    },
                    new ShellContent
                    {
                        Title = "Media Data",
                        Route = "mediaData",
                        ContentTemplate = new DataTemplate(typeof(MediaDataPage))
                    }
                }
            };

            var historical = new FlyoutItem
            {
                Title = "Historical",
                Route = "historical",
                FlyoutIcon = GetIcon(MaterialSharp.History),
                Items =
                {
                    historicalTab,
                }
            };
    
            Items.Add(dashboard);
            Items.Add(cameraView);
            Items.Add(eventView);
            Items.Add(historical);
            
            AppShell.InitializeRouting();
            
            InitializeComponent();
        }

        private static void InitializeRouting() 
        { 
            Routing.RegisterRoute("dashboard/healthMonitor", typeof(Views.Dashboard.HealthMonitorPage));
            Routing.RegisterRoute("dashboard/edgeDetail", typeof(Views.Detail.EdgeDetailPage));
            Routing.RegisterRoute("dashboard/edgeDetail/healthMonitor", typeof(HealthMonitorPage));
            Routing.RegisterRoute("eventView/eventDetail", typeof(Views.Detail.EventDetailPage));
            Routing.RegisterRoute("eventView/eventDetail/mediaDetail", typeof(Views.Detail.MediaDetailPage));
        }

        private void LogoutMenuItem_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = _serviceProvider.GetRequiredService<LoginPage>();
            // Add logic for logout
        }

        private void AssignAccess()
        {
            
        }
        
        private FontImageSource GetIcon(string iconName)
        {
            return new FontImageSource
            {
                FontFamily = "MaterialSharp",
                Glyph = iconName,
                Color = Application.Current.Resources["Gray700"] as Color
            };
        }
    }
}
