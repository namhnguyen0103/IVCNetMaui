using IVCNetMaui.Models;
using IVCNetMaui.Services.Credential;
using IVCNetMaui.Services.RequestProvider;

namespace IVCNetMaui.Services.Api;

public class ApiService : IApiService
{
    private readonly HttpClient _httpClient;
    private readonly IRequestProvider  _requestProvider;
    private readonly ICredentialService  _credentialService;
    private readonly GlobalSetting _globalSetting;

    public ApiService(IRequestProvider requestProvider, ICredentialService credentialService, GlobalSetting globalSetting)
    {
        _httpClient = new HttpClient();
        _requestProvider = requestProvider;
        _credentialService = credentialService;
        _globalSetting = globalSetting;
    }
    
    public async Task<List<Permission>> GetPermissions()
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

    public async Task<List<Unit>> GetVideoFeeds()
    {
        try
        {
            var response = await _requestProvider.GetAsync<List<Unit>>($"{_globalSetting.BaseApiEndpoint}/video/feeds");
            Console.WriteLine("ApiService Video Retrieved!");
            Console.WriteLine("Response : {0}", response[0]);
            return response;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}