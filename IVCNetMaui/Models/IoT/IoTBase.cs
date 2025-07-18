namespace IVCNetMaui.Models.IoT;

public class IoTBase
{
    public int Id { get; set; } = -1;
    public string? Name { get; set; }
    public int Status { get; set; }
    public string? IpAddress { get; set; }
    public int Port { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public IoTStatus? IoTStatus { get; set; }
}