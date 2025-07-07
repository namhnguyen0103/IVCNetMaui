using IVCNetMaui.Models;

namespace IVCNetMaui;

public class GlobalSetting
{
    public Task ResetGlobalSettingAsync()
    {
        BaseApiEndpoint = string.Empty;
        Permissions = new List<Permission>();
        Roles = new List<Role>();
        Units = new List<Unit>();
        Flags = new()
        {
            {100, 0},
            {101, 0},
            {102, 0},
            {103, 0},
            {104, 0},
            {105, 0},
            {106, 0},
        };
        return Task.CompletedTask;
    }
    
    public string BaseApiEndpoint { get; set; } = string.Empty;
    private List<Permission> _permissions =  new();
    public List<Permission> Permissions
    {
        get => _permissions;
        set
        {
            _permissions = value.Where(perm => perm.PermType == 3).ToList();
            foreach (var perm in _permissions)
            {
                Flags[perm.Id] = perm.Bitmask;
            }
        }
    }
    
    public List<Role> Roles { get; set; } = new List<Role>();
    public List<Unit> Units { get; set; } = new List<Unit>();

    public Dictionary<int, int> Flags = new()
    {
        {100, 0},
        {101, 0},
        {102, 0},
        {103, 0},
        {104, 0},
        {105, 0},
        {106, 0},
    };
}