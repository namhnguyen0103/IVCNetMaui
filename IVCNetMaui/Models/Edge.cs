using IVCNetMaui.Models.Authentication;
using IVCNetMaui.Models.Metric;

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

public class EdgeHealth
{
    public System? System { get; set; }
    public Process? Vae_ui { get; set; }
    public Process? Vae_video { get; set; }
}

public class Process
{
    public string? State { get; set; }
    public string? Error { get; set; }
    public int Pid { get; set; }
    public DateTime? LastExitTime { get; set; }
    public int? LastExitCode { get; set; }
    public Cpu? Cpus { get; set; }
    public Ram? RamBytes { get; set; }
    public int Threads { get; set; }
    public int Handles { get; set; }
}

public class System
{
    public SystemInfo? Info { get; set; }
    public Cpu? Cpus { get; set; }
    public Dictionary<String, Disk>? RamBytes { get; set; }
    public Dictionary<String, Disk>? DiskBytes { get; set; }
    public Dictionary<String, Metric.Network>? Network { get; set; }
}

public class SystemInfo
{
    public string? MachineName { get; set; }
    public string? OsVersion { get; set; }
    public DateTime Started { get; set; }
    public TimeSpan UpTime { get; set; }
}

public class Cpu
{
    public double Total { get; set; }
    public double Used { get; set; }
}

public class HealthMetricRoot
{
    public EdgeHealth? HealthMetrics { get; set; }
}

