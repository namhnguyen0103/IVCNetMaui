using IVCNetMaui.Models;

namespace IVCNetMaui;

public class GlobalSetting
{
    public string BaseApiEndpoint { get; set; } = string.Empty;
    
    public List<Permission> Permissions { get; set; } = new List<Permission>();
}