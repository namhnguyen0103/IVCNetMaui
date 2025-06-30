namespace IVCNetMaui.Services.Authentication;

public interface IAuthenticationService
{
    Task<string> LoginAsync(string username, string password);
    Task LogoutAsync();
}