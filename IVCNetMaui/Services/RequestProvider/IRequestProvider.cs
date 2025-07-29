namespace IVCNetMaui.Services.RequestProvider;

public interface IRequestProvider
{
    Task<TResult> GetAsync<TResult>(string uri);
    
    Task<TResult> PostAsync<TResult, TInput>(string uri, TInput data);
    Task PutAsync(string uri);
    Task<TResult> PutAsync<TResult>(string uri);
    Task<TResult> PutAsync<TResult, TInput>(string uri, TInput data);
    
    Task DeleteAsync<TResult>(string uri);
}