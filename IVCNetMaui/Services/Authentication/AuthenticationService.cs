using System.Net;
using System.Net.Http.Headers;
using System.Text;
using IVCNetMaui.Models;
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
    public async Task<bool> LoginAsync(LoginCredential loginCredential)
    {
        try
        {
            await _credentialService.SaveAsync(loginCredential.Username, loginCredential.Password);
            var uri = $"http://{loginCredential.Ip}:{loginCredential.Port}/" + ApiUrlBase;
            var response = await _requestProvider.GetAsync<string>(uri);
            
            Console.WriteLine("AuthenticationService Login Success!");
            Console.WriteLine("Response : {0}", response);
            
            return true;
        }
        catch (ServiceAuthenticationException ex)
        {
            Console.WriteLine("AuthenticationService Exception Caught!");
            Console.WriteLine("Message : {0} ", ex.Message);
            return false;
        }
    }

    public Task LogoutAsync()
    {
        throw new NotImplementedException();
    }
}