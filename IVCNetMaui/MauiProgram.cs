using CommunityToolkit.Maui;
using IVCNetMaui.ViewModels.Dashboard;
using IVCNetMaui.Views.Dashboard;
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
            }).UseMauiCommunityToolkit();
#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<HubHealthMonitorViewModel>();
            builder.Services.AddSingleton<HubHealthMonitorPage>();
            
            return builder.Build();
        }

        public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<HubHealthMonitorPage>();
            
            return mauiAppBuilder;
        }
    }
}