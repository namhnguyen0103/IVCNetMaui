namespace IVCNetMaui.Models;

public class Permission
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsAdminPerm { get; set; }
    public int PermType { get; set; }
    public int Bitmask { get; set; }
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }

    public override string ToString()
    {
        return $"Name: {Name}\n" +
               $"Description: {Description}\n" +
               $"IsAdminPerm: {IsAdminPerm}\n" +
               $"PermType: {PermType}\n" +
               $"Bitmask: {Bitmask}\n" +
               $"Id: {Id}\n" +
               $"CreatedDate: {CreatedDate}\n" +
               $"ModifiedDate: {ModifiedDate}";
    }
}