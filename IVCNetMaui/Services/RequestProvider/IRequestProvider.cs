namespace IVCNetMaui.Services.RequestProvider;

public interface IRequestProvider
{
    Task<TResult> GetAsync<TResult>(string uri);
    
    Task<TResult> PostAsync<TResult>(string uri, TResult data,  string header = "");
    
    Task<TResult> PutAsync<TResult>(string uri, string clientId, string clientSecret);
    
    Task DeleteAsync<TResult>(string uri);
}