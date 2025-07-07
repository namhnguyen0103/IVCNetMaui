namespace IVCNetMaui.Models;

public class CurrentLocalApiUserInfo
{
    public string AuthScheme { get; set; } = string.Empty;
    public string DomainName { get; set; } = string.Empty;
    public bool IsAuthenticated { get; set; }
    public string UserName { get; set; } = string.Empty;
    public Dictionary<string, string> Claims { get; set; }  = new Dictionary<string, string>();
    public string[] Roles { get; set; }  = Array.Empty<string>();
    public List<Permission> Permissions { get; set; } = new List<Permission>();
}