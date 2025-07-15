using IVCNetMaui.Models;
using IVCNetMaui.Models.Authentication;
using IVCNetMaui.Models.HealthStatus;

namespace IVCNetMaui.Services.Api;

public interface IApiService
{
    Task<List<Permission>> GetPermissionsAsync();
    Task<List<Unit>> GetVideoFeedsAsync();
    Task<List<Role>> GetRoleAsync();
    Task<CurrentLocalApiUserInfo> GetUserInfoAsync();
    Task<HealthStatus> GetHealthStatusAsync();
    Task<List<Edge>> GetVaEdgeUnitsAsync();
    Task<EdgeStatus> GetEdgeStatusAsync(int unit);
    Task<HealthStatus> GetVaEdgeUnitHealthStatusAsync(int unit);
}