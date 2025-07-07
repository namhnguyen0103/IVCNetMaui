namespace IVCNetMaui.Models.HealthStatus;

public class HealthStatus
{
    public SystemStatus SystemStatus { get; set; } = new SystemStatus();
    public ProcessStatus VideoProcessStatus { get; set; } = new ProcessStatus();
    public ProcessStatus UiProcessStatus { get; set; } = new ProcessStatus();
}