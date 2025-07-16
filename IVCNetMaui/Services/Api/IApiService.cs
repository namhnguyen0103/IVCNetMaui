using IVCNetMaui.Models;
using IVCNetMaui.Models.Authentication;
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
    Task<EdgeHealth?> GetEdgeHealthAsync(int unit);
}