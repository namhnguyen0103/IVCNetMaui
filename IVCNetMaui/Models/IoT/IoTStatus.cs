namespace IVCNetMaui.Models.IoT;

public class IoTStatus
{
    public string? UnitName { get; set; }
    public string? UnitId { get; set; }
    public string? IotName { get; set; }
    public string? IotId { get; set; }
    public string Status { get; set; } = "Unknown";
    public string? Reason { get; set; }
}