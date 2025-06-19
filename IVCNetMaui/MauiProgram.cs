using CommunityToolkit.Maui;
using IVCNetMaui.Services.Navigation;
using IVCNetMaui.ViewModels;
using IVCNetMaui.ViewModels.Dashboard;
using IVCNetMaui.ViewModels.Detail;
using IVCNetMaui.ViewModels.Historical;
using IVCNetMaui.ViewModels.View;
using IVCNetMaui.Views;
using IVCNetMaui.Views.Dashboard;
using IVCNetMaui.Views.Detail;
using IVCNetMaui.Views.Historical;
using IVCNetMaui.Views.View;
using Microsoft.Extensions.Logging;
using UraniumUI;

namespace IVCNetMaui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>()
                   .UseMauiCommunityToolkit()
                   .UseMauiCommunityToolkitMediaElement()
                   .UseUraniumUI()
                   .UseUraniumUIMaterial()
                   .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Nunito-VariableFont_wght.ttf", "Nunito");
                fonts.AddFont("Nunito-Light.ttf", "NunitoLight");
                fonts.AddFont("Nunito-Regular.ttf", "NunitoRegular");
                fonts.AddFont("Nunito-Medium.ttf", "NunitoMedium");
                fonts.AddFont("Nunito-Bold.ttf", "NunitoBold");
                fonts.AddFont("Roboto-Light.ttf", "RobotoLight");
                fonts.AddFont("Roboto-Regular.ttf", "RobotoRegular");
                fonts.AddFont("Roboto-Medium.ttf", "RobotoMedium");
                fonts.AddFont("Roboto-SemiBold.ttf", "RobotoSemiBold");
                fonts.AddMaterialSymbolsFonts();
            }).UseMauiCommunityToolkit();
#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder
                .RegisterAppServices()
                .RegisterViewModels()
                .RegisterViews();
            
            return builder.Build();
        }

        private static MauiAppBuilder RegisterAppServices(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<INavigationService, MauiNavigationService>();
            
            return builder;
        }
        private static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<DashboardMainViewModel>();
            builder.Services.AddSingleton<EventViewModel>();
            builder.Services.AddSingleton<HistoricalHealthDataViewModel>();

            
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<HealthMonitorViewModel>();
            builder.Services.AddTransient<EdgeDetailViewModel>();
            builder.Services.AddTransient<IoTListViewModel>();
            builder.Services.AddTransient<CameraViewModel>();
            builder.Services.AddTransient<EventDetailViewModel>();
            builder.Services.AddTransient<MediaDetailViewModel>();
            
            return builder;
        }
        
        private static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<DashboardMainPage>();
            builder.Services.AddSingleton<EventPage>();
            builder.Services.AddSingleton<HistoricalHealthDataPage>();
            
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<HealthMonitorPage>();
            builder.Services.AddTransient<EdgeDetailPage>();
            builder.Services.AddTransient<IoTListPage>();
            builder.Services.AddTransient<CameraPage>();
            builder.Services.AddTransient<EventDetailPage>();
            builder.Services.AddTransient<MediaDetailPage>();

            return builder;
        }
    }
}