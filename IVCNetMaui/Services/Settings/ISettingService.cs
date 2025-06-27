namespace IVCNetMaui.Services.Settings;

public interface ISettingService
{
    string AuthAccessToken { get; set; }
    string AuthIdToken { get; set; }
    
}