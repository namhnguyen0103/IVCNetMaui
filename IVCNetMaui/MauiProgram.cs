using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

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
            return builder.Build();
        }
    }
}