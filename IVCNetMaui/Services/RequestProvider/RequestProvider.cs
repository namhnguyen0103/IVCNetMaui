using System.Net;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using IVCNetMaui.Services.Authentication;
using IVCNetMaui.Services.Credential;

namespace IVCNetMaui.Services.RequestProvider;

public class RequestProvider(ICredentialService credentialService) : IRequestProvider
{
    private readonly Lazy<HttpClient> _httpClient =
        new(() =>
            {
                var httpClient = new HttpClient();
                return httpClient;
                
            }, LazyThreadSafetyMode.ExecutionAndPublication);

    public async Task<TResult> GetAsync<TResult>(string uri)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, uri);
        await AddAuthorizationHeaderAsync(request);

        HttpResponseMessage response = await _httpClient.Value.SendAsync(request);
        
        await HandleResponse(response);
        
        if (typeof(TResult) == typeof(string))
        {
            string raw = await response.Content.ReadAsStringAsync();
            return (TResult)(object)raw;
        }
        if (typeof(TResult) == typeof(Stream))
        {
            var stream = await response.Content.ReadAsStreamAsync();
            return (TResult)(object)stream;
        }
        
        return await DeserializeResponse<TResult>(response);
    }

    public async Task<TResult> PostAsync<TResult, TInput>(string uri, TInput data)
    {
        string json = JsonSerializer.Serialize(data);
        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
        var request = new HttpRequestMessage(HttpMethod.Post, uri)
        {
            Content = content
        };
        await AddAuthorizationHeaderAsync(request);

        HttpResponseMessage response = await _httpClient.Value.SendAsync(request);
        
        await HandleResponse(response);
        
        return await DeserializeResponse<TResult>(response);;
    }

    public async Task PutAsync(string uri)
    {
        var request = new HttpRequestMessage(HttpMethod.Put, uri);
        await AddAuthorizationHeaderAsync(request);

        HttpResponseMessage response = await _httpClient.Value.SendAsync(request);
        
        await HandleResponse(response);
    }
    
    public async Task<TResult> PutAsync<TResult>(string uri)
    {
        var request = new HttpRequestMessage(HttpMethod.Put, uri);
        await AddAuthorizationHeaderAsync(request);

        HttpResponseMessage response = await _httpClient.Value.SendAsync(request);
        
        await HandleResponse(response);
        
        var result = await response.Content.ReadFromJsonAsync<TResult>();
        if (result == null)
            throw new DeserializationException($"Failed to deserialize response to {typeof(TResult).Name}.");

        return result;
    }
    
    public async Task<TResult> PutAsync<TResult, TInput>(string uri, TInput data)
    {
        string json = JsonSerializer.Serialize(data);
        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
        var request = new HttpRequestMessage(HttpMethod.Put, uri)
        {
            Content = content
        };
        
        await AddAuthorizationHeaderAsync(request);

        HttpResponseMessage response = await _httpClient.Value.SendAsync(request);
        
        await HandleResponse(response);
        
        return await DeserializeResponse<TResult>(response);;
    }

    public Task DeleteAsync<TResult>(string uri)
    {
        throw new NotImplementedException();
    }

    private async Task AddAuthorizationHeaderAsync(HttpRequestMessage request)
    {
        var credential = await credentialService.GetAsync();
        var bytesArray = credential is null
            ? null
            : Encoding.ASCII.GetBytes($"{credential.Value.Username}:{credential.Value.Password}");
        
        if (bytesArray != null)
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(bytesArray));
    }
    
    private static async Task HandleResponse(HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == HttpStatusCode.Forbidden || response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new ServiceAuthenticationException(content);
            }
            
            throw new HttpRequestException(content);
        }
    }

    private static async Task<TResult> DeserializeResponse<TResult>(HttpResponseMessage response)
    {
        var responseContent = await response.Content.ReadFromJsonAsync<TResult>();
        if (responseContent == null) throw new DeserializationException($"Failed to deserialize response to {typeof(TResult).Name}.");
        return responseContent;
    }
}

public class DeserializationException(string message) : Exception(message);
