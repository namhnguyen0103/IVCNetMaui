using IVCNetMaui.Models;

namespace IVCNetMaui.Services.Api;

public interface IApiService
{
    Task<List<Permission>> GetPermissionsAsync();
    Task<List<Unit>> GetVideoFeedsAsync();
    Task<List<Role>> GetRoleAsync();
    Task<CurrentLocalApiUserInfo> GetUserInfoAsync();
}