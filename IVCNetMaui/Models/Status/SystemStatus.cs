using IVCNetMaui.Models.Metric;

namespace IVCNetMaui.Models.Status;

public class SystemStatus
{
    public string? MachineName { get; set; }
    public string? OsVersion { get; set; }
    public DateTime Started { get; set; }
    public TimeSpan UpTime { get; set; }
    public double CpuTotal { get; set; }
    public double CpuUsed { get; set; }
    public long RamPhysicalTotal { get; set; }
    public long RamPhysicalUsed { get; set; }
    public long RamVirtualTotal { get; set; }
    public long RamVirtualUsed { get; set; }
    public Disk[] Disks { get; set; } = [];
    public Metric.Network[] Network { get; set; } =  [];
}