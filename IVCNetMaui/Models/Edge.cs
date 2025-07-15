using IVCNetMaui.Models.Authentication;

namespace IVCNetMaui.Models;

public class Edge
{
    public bool SoftDeleted { get; set; }
    public int Status { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int ProtocolScheme { get; set; }
    public string? IpAddress { get; set; }
    public int WebHttpPort { get; set; }
    public int WebHttpsPort { get; set; }
    public int VideoHttpPort { get; set; }
    public int VideoHttpsPort { get; set; }
    public int HealthMonitorHttpPort { get; set; }
    public int HealthMonitorHttpsPort { get; set; }
    public int AlarmHttpPort { get; set; }
    public int AlarmHttpsPort { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public bool GuardScanOn { get; set; }
    public int GuardScanRate { get; set; }
    public int AlarmSubscribeProtocols { get; set; }
    public int DataSubscribeProtocols { get; set; }
    public string? MqttGroupId { get; set; }
    public string? MqttNodeId { get; set; }
    public int AlarmSubscribeMqttServerId { get; set; }
    public int AlarmSubscribeSparkplugBServerId { get; set; }
    public int DataSubscribeMqttServerId { get; set; }
    public int DataSubscribeSparkplugBServerId { get; set; }
    public string? LicenseSerial { get; set; }
    public int NumLicensedFeeds { get; set; }
    public Feed[] Feeds { get; set; } = [];
    public int Id { get; set; } = -1;
    public EdgeStatus? EdgeStatus { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
}

public class EdgeStatus
{
    public string? Version { get; set; }
    public string? UiStatus { get; set; }
    public string? VeStatus { get; set; }
    public string? UnitName { get; set; }
    public string? UnitId { get; set; }
    public string? Licid { get; set; }
    public string? Licserial { get; set; }
    public string? Licissuer { get; set; }
    public string? Licexpiration { get; set; }
    public int Licfeeds { get; set; }
    public string? Licstatus { get; set; }
}