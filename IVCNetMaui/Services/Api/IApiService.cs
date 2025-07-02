using IVCNetMaui.Models;

namespace IVCNetMaui.Services.Api;

public interface IApiService
{
    Task<List<Permission>> GetPermissions();
}