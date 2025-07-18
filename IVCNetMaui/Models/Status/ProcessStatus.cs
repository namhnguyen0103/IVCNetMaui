namespace IVCNetMaui.Models.Status;

public class ProcessStatus
{
    public string? ApplicationName { get; set; }
    public string? State { get; set; } 
    public string? Error { get; set; } 
    public int Pid { get; set; }
    public DateTime? LastExitTime { get; set; }
    public int? LastExitCode { get; set; } = -1;
    public int CpuTotal { get; set; }
    public double CpuUsed { get; set; }
    public long RamPeakWorking { get; set; }
    public long RamWorking { get; set; }
    public int RamPaged { get; set; }
    public int RamPeakPaged { get; set; }
    public int Threads { get; set; }
    public int Handles { get; set; }
}