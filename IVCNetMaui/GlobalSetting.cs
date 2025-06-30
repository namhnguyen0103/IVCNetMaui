namespace IVCNetMaui;

public class GlobalSetting
{
    private const string DefaultEndpoints = "http://192.168.25.42:7181/";
    public static GlobalSetting Instance { get; } = new GlobalSetting();

    public string GetDefaultEndpoints
    {
        get => DefaultEndpoints;
    }
}