using System.Net.Http.Headers;
using System.Text;
using IVCNetMaui.Services.Credential;
using IVCNetMaui.Services.RequestProvider;

namespace IVCNetMaui.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly HttpClient _httpClient;
    private readonly IRequestProvider _requestProvider;
    private readonly ICredentialService _credentialService;
    
    private const string ApiUrlBase = "api/v1/version";

    public AuthenticationService(IRequestProvider requestProvider, ICredentialService credentialService)
    {
        _httpClient = new HttpClient();
        _requestProvider = requestProvider;
        _credentialService = credentialService;
    }
    public async Task<string> LoginAsync(string username, string password)
    {
        await _credentialService.SaveAsync(username, password);
        var response = await _requestProvider.GetAsync<string>(GlobalSetting.Instance.GetDefaultEndpoints + ApiUrlBase);
        return response;
    }

    public Task LogoutAsync()
    {
        throw new NotImplementedException();
    }
}