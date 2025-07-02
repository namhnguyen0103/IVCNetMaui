using IVCNetMaui.Models;

namespace IVCNetMaui.Services.Authentication;

public interface IAuthenticationService
{
    Task<bool> LoginAsync(LoginCredential loginCredential);
    Task LogoutAsync();
}