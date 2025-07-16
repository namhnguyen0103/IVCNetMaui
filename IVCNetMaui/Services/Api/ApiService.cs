using System.Text.Json;
using IVCNetMaui.Models;
using IVCNetMaui.Models.Authentication;
using IVCNetMaui.Models.Status;
using IVCNetMaui.Services.Credential;
using IVCNetMaui.Services.RequestProvider;

namespace IVCNetMaui.Services.Api;

public class ApiService : IApiService
{
    private readonly HttpClient _httpClient;
    private readonly IRequestProvider  _requestProvider;
    private readonly GlobalSetting _globalSetting;

    public ApiService(IRequestProvider requestProvider, GlobalSetting globalSetting)
    {
        _httpClient = new HttpClient();
        _requestProvider = requestProvider;
        _globalSetting = globalSetting;
    }
    
    public async Task<List<Permission>> GetPermissionsAsync()
    {
        try
        {
            var response = await _requestProvider.GetAsync<List<Permission>>($"{_globalSetting.BaseApiEndpoint}/permissions");
            Console.WriteLine("ApiService Permissions Retrieved!");
            Console.WriteLine("Response : {0}", response);
            return response;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<List<Role>> GetRoleAsync()
    {
        try
        {
            var response = 
                await _requestProvider.PostAsync<List<Role>, string[]>($"{_globalSetting.BaseApiEndpoint}/Roles/ByGroupNames", _globalSetting.ApiUserInfo.Roles);
            return response;
        }
        catch (Exception e)
        {
            Console.WriteLine("ApiService Exception Caught!");
            Console.WriteLine("Message: {0}",  e.Message);
        }

        return [];
    }

    public async Task<List<Unit>> GetVideoFeedsAsync()
    {
        try
        {
            var response = await _requestProvider.GetAsync<List<Unit>>($"{_globalSetting.BaseApiEndpoint}/video/feeds");
            Console.WriteLine("ApiService Video Retrieved!");
            Console.WriteLine("Response : {0}", response);
            return response;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<CurrentLocalApiUserInfo> GetUserInfoAsync()
    {
        try
        {
            var response =
                await _requestProvider.GetAsync<CurrentLocalApiUserInfo>(
                    $"{_globalSetting.BaseApiEndpoint}/auth/currentlocalapiuserinfo");
            Console.WriteLine("ApiService User Info Retrieved!");
            Console.WriteLine("Response : {0}", response);
            return response;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<HealthStatus> GetHealthStatusAsync()
    {
        try
        {
            var response =
                await _requestProvider.GetAsync<HealthStatus>(
                    $"{_globalSetting.BaseApiEndpoint}/health/status?appname");
            Console.WriteLine("ApiService Health Status Retrieved!");
            Console.WriteLine("Response : {0}", response);
            return response;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<List<Edge>> GetEdgesAsync()
    {
        try
        {
            var response = await _requestProvider.GetAsync<List<Edge>>($"{_globalSetting.BaseApiEndpoint}/vaedgeunit");
            return response;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<EdgeStatus> GetEdgeStatusAsync(int unit)
    {
        try
        {
            var response = await _requestProvider.GetAsync<EdgeStatus>($"{_globalSetting.BaseApiEndpoint}/vaedge/status?unit={unit}");
            return response;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<EdgeHealth?> GetEdgeHealthAsync(int unit)
    {
        try
        {
            var response = await _requestProvider.GetAsync<HealthMetricRoot>($"{_globalSetting.BaseApiEndpoint}/vaedge/health/status?unit={unit}");
            return response.HealthMetrics;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}