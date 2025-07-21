namespace IVCNetMaui.Models.Status;

public class ProcessStatus
{
    public string? ApplicationName { get; set; }
    public string? State { get; set; } 
    public string? Error { get; set; } 
    public int Pid { get; set; }
    public DateTime? LastExitTime { get; set; }
    public int? LastExitCode { get; set; } = -1;
    public double CpuTotal { get; set; }
    public double CpuUsed { get; set; }
    public long RamPeakWorking { get; set; }
    public long RamWorking { get; set; }
    public long RamPaged { get; set; }
    public long RamPeakPaged { get; set; }
    public int Threads { get; set; }
    public int Handles { get; set; }
}