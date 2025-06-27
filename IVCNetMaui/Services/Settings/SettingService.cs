namespace IVCNetMaui.Services.Settings;

public class SettingService : ISettingService
{
    // Setting Constants
    
    private const string AccessToken = "access_token";
    private const string IdToken = "id_token";

    private readonly string _accessTokenDefault = string.Empty;
    private readonly string _idTokenDefault = string.Empty;
    
    // Setting Properties
    public string AuthAccessToken
    {
        get => Preferences.Get(AccessToken, _accessTokenDefault); 
        set => Preferences.Set(AccessToken, value);
    }

    public string AuthIdToken
    {
        get => Preferences.Get(IdToken, _idTokenDefault); 
        set => Preferences.Set(IdToken, value);
    }
}