namespace IVCNetMaui.Models.HealthStatus;

public class Network
{
    public string InterfaceId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int NetworkInterfaceType { get; set; }
    public double BytesSendPerSecond { get; set; }
    public double BytesReceivePerSecond { get; set; }
    public int PacketsQueued { get; set; }
}