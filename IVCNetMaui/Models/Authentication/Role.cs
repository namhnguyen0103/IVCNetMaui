namespace IVCNetMaui.Models.Authentication;

public class Role
{
    public int Status { get; set; }
    public string? Description { get; set; }
    public string? RoleAdGroups { get; set; }
    public List<RoleFeedPermission>? RoleFeedPermissions { get; set; }
    public int MobileAppPermFlags { get; set; }
    public int WebPortalPermFlags { get; set; }
    public int ViewStationPermFlags { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? NormalizedName  { get; set; }
    public string? ConcurrencyStamp { get; set; }
}