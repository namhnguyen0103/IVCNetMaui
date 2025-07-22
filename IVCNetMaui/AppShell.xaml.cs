using IVCNetMaui.Models;
using IVCNetMaui.Views;
using IVCNetMaui.Views.Dashboard;
using IVCNetMaui.Views.Historical;
using IVCNetMaui.Views.Detail;
using IVCNetMaui.Views.View;
using UraniumUI.Icons.MaterialSymbols;

namespace IVCNetMaui
{
    public partial class AppShell : Shell
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly GlobalSetting _globalSetting;
        public AppShell(IServiceProvider serviceProvider,  GlobalSetting globalSetting)
        {
            _serviceProvider = serviceProvider;
            _globalSetting = globalSetting;

            InitializeAccess();
            InitializeComponent();
        }

        private async void LogoutMenuItem_Clicked(object sender, EventArgs e)
        {
            await _globalSetting.ResetGlobalSettingAsync();
            Application.Current.MainPage = _serviceProvider.GetRequiredService<LoginPage>();
            // Add logic for logout
        }

        private void InitializeAccess()
        {
            var webPortalFlag = _globalSetting.Roles[0].WebPortalPermFlags;

            // Allow access to Navigation Section
            if ((webPortalFlag & _globalSetting.Flags[100]) != 0)
            {
                Items.Add(new FlyoutItem
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
                });
                Routing.RegisterRoute("dashboard/healthMonitor", typeof(HealthMonitorPage));
                Routing.RegisterRoute("dashboard/edgeDetail", typeof(EdgeDetailPage));
                Routing.RegisterRoute("dashboard/edgeDetail/healthMonitor", typeof(HealthMonitorPage));
            }

            // Allow access to Views Section
            if ((webPortalFlag & _globalSetting.Flags[101]) != 0)
            {
                Items.Add(new FlyoutItem
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
                });
                Items.Add(new FlyoutItem
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
                });
                Routing.RegisterRoute("eventView/eventDetail", typeof(EventDetailPage));
                Routing.RegisterRoute("eventView/eventDetail/mediaDetail", typeof(MediaDetailPage));
            }

            // Allow access to Historical Section
            if ((webPortalFlag & _globalSetting.Flags[102]) != 0)
            {
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
                Items.Add(new FlyoutItem
                {
                    Title = "Historical",
                    Route = "historical",
                    FlyoutIcon = GetIcon(MaterialSharp.History),
                    Items =
                    {
                        historicalTab,
                    }
                });
            }
            
            Routing.RegisterRoute("filterModal", typeof(EventFilterPage));
        }
        
        private static FontImageSource GetIcon(string iconName)
        {
            return new FontImageSource
            {
                FontFamily = "MaterialSharp",
                Glyph = iconName,
                Color = Application.Current?.Resources["Gray700"] as Color ?? Color.FromRgb(255, 255, 255)
            };
        }
    }
}
