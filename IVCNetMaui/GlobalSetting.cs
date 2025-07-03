using IVCNetMaui.Models;

namespace IVCNetMaui;

public class GlobalSetting
{
    public string BaseApiEndpoint { get; set; } = string.Empty;

    private List<Permission> _permissions =  new();
    public List<Permission> Permissions
    {
        get => _permissions;
        set
        {
            _permissions = value.Where(perm => perm.PermType == 3).ToList();
        }
    }
    
    public List<Unit> Units { get; set; } = new List<Unit>();
}