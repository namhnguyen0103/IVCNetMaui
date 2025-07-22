using IVCNetMaui.Models;
using IVCNetMaui.Models.Authentication;
using IVCNetMaui.Models.IoT;
using IVCNetMaui.Models.Status;

namespace IVCNetMaui.Services.Api;

public interface IApiService
{
    Task<List<Permission>> GetPermissionsAsync();
    Task<List<Unit>> GetVideoFeedsAsync();
    Task<List<Role>> GetRoleAsync();
    Task<CurrentLocalApiUserInfo> GetUserInfoAsync();
    Task<HealthStatus> GetHealthStatusAsync();
    Task<List<Edge>> GetEdgesAsync();
    Task<EdgeStatus> GetEdgeStatusAsync(int unit);
    Task<HealthStatus?> GetEdgeHealthAsync(int unit);
    Task<List<Camera>> GetCamerasAsync(int unit);
    Task<List<ModbusDevice>> GetModbusDeviceAsync(int unit);
    Task<List<WeatherStation>> GetWeatherStationAsync(int unit);
    Task<IoTStatus> GetIoTStatusAsync(int unit, string type, int iot);
    Task<List<Event>> GetEventsAsync();
    Task<int> GetEventCountAsync();
}