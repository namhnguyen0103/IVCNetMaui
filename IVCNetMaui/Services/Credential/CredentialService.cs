namespace IVCNetMaui.Services.Credential;

public class CredentialService : ICredentialService
{
    public async Task SaveAsync(string username, string password)
    {
        await SecureStorage.SetAsync("username", username);
        await SecureStorage.SetAsync("password", password);
    }

    public async Task<(string Username, string Password)?> GetAsync()
    {
        var username = await SecureStorage.GetAsync("username");
        var password = await SecureStorage.GetAsync("password");

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            return null;

        return (username, password);
    }

    public Task ClearAsync()
    {
        SecureStorage.Remove("username");
        SecureStorage.Remove("password");
        return Task.CompletedTask;
    }
}