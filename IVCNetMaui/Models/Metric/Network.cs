namespace IVCNetMaui.Models.Metric;

public class Network
{
    public string? InterfaceId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int NetworkInterfaceType { get; set; }
    public double BytesSendPerSecond { get; set; }
    public double BytesReceivePerSecond { get; set; }
    public int PacketsQueued { get; set; }
}