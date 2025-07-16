namespace IVCNetMaui.Models.Status;

public class HealthStatus
{
    public SystemStatus? SystemStatus { get; set; } 
    public ProcessStatus? VideoProcessStatus { get; set; } 
    public ProcessStatus? UiProcessStatus { get; set; }
}