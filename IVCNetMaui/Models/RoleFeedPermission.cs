namespace IVCNetMaui.Models;

public class RoleFeedPermission
{
    public int UnitId { get; set; }
    public int FeedId { get; set; }
    public int FeedPermFlags { get; set; }
    public string ApplicationRoleId  { get; set; }
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
}