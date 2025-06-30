namespace IVCNetMaui.Services.Credential;

public interface ICredentialService
{
    Task SaveAsync(string username, string password);
    Task<(string Username, string Password)?> GetAsync();
    Task ClearAsync();
}