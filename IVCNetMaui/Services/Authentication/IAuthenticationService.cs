using IVCNetMaui.Models;
using IVCNetMaui.Models.Authentication;

namespace IVCNetMaui.Services.Authentication;

public interface IAuthenticationService
{
    Task<bool> LoginAsync(LoginCredential loginCredential);
    Task LogoutAsync();
}