namespace IVCNetMaui.Services.DeviceInfo;

public class DeviceInfoService : IDeviceInfoService
{
    public DeviceIdiom GetDeviceIdiom()
    {
        return Microsoft.Maui.Devices.DeviceInfo.Current.Idiom;
    }
}