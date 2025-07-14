namespace IVCNetMaui.Models.HealthStatus;

public class Disk
{
    public string? DiskName { get; set; }
    public long Total { get; set; }
    public long Used { get; set; }
    public long Available { get; set; }
}