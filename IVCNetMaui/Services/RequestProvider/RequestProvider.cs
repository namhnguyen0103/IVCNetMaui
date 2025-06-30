using System.Net.Http.Headers;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using IVCNetMaui.Services.Credential;

namespace IVCNetMaui.Services.RequestProvider;

public class RequestProvider : IRequestProvider
{
    private readonly Lazy<HttpClient> _httpClient =
        new(() =>
            {
                var httpClient = new HttpClient();
                return httpClient;
                
            }, LazyThreadSafetyMode.ExecutionAndPublication);
    
    private readonly ICredentialService _credentialService;

    public RequestProvider(ICredentialService credentialService)
    {
        _credentialService = credentialService;
    }
    
    public async Task<TResult> GetAsync<TResult>(string uri)
    {
        HttpClient httpClient = _httpClient.Value;
        var credential = await _credentialService.GetAsync();
        
        var request = new HttpRequestMessage(HttpMethod.Get, uri);
        
        var byteArray = Encoding.ASCII.GetBytes($"{credential.Value.Username}:{credential.Value.Password}");
        request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
        
        HttpResponseMessage response = await httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
        if (typeof(TResult) == typeof(string))
        {
            string raw = await response.Content.ReadAsStringAsync();
            return (TResult)(object)raw;
        }
        return await response.Content.ReadFromJsonAsync<TResult>();
    }

    public Task<TResult> PostAsync<TResult>(string uri, TResult data, string header = "")
    {
        throw new NotImplementedException();
    }

    public Task<TResult> PutAsync<TResult>(string uri, string clientId, string clientSecret)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync<TResult>(string uri)
    {
        throw new NotImplementedException();
    }

    // private static void AddBasicAuthenticationHeader(HttpClient httpClient, string clientId, string clientSecret)
    // {
    //     if (string.IsNullOrWhiteSpace(clientId) || string.IsNullOrWhiteSpace(clientSecret))
    //         return;
    //     
    //     var byteArray = Encoding.ASCII.GetBytes($"{clientId}:{clientSecret}");
    //     httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
    // }
}