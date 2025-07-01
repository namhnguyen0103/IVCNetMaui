namespace IVCNetMaui.Services.Authentication;

public interface IAuthenticationService
{
    Task<string> LoginAsync(string username, string password, string ip, int port, string type);
    Task LogoutAsync();
}