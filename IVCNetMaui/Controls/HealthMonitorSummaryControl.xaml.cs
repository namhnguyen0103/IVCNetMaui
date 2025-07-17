using IVCNetMaui.Models.Status;
using IVCNetMaui.Services.Navigation;

namespace IVCNetMaui.Controls;

public partial class HealthMonitorSummaryControl
{
    public static readonly BindableProperty NavigateToSystemCommandProperty =
        BindableProperty.Create(nameof(NavigateToSystemCommand), typeof(AsyncRelayCommand), typeof(HealthMonitorSummaryControl));

    public AsyncRelayCommand NavigateToSystemCommand
    {
        get => (AsyncRelayCommand)GetValue(NavigateToSystemCommandProperty);
        set => SetValue(NavigateToSystemCommandProperty, value);
    }
    
    public static readonly BindableProperty NavigateToVideoProcessCommandProperty =
        BindableProperty.Create(nameof(NavigateToVideoProcessCommand), typeof(AsyncRelayCommand), typeof(HealthMonitorSummaryControl));

    public AsyncRelayCommand NavigateToVideoProcessCommand
    {
        get => (AsyncRelayCommand)GetValue(NavigateToVideoProcessCommandProperty);
        set => SetValue(NavigateToVideoProcessCommandProperty, value);
    }
    
    public static readonly BindableProperty NavigateToUiProcessCommandProperty =
        BindableProperty.Create(nameof(NavigateToUiProcessCommand), typeof(AsyncRelayCommand), typeof(HealthMonitorSummaryControl));
    
    public AsyncRelayCommand NavigateToUiProcessCommand
    {
        get => (AsyncRelayCommand)GetValue(NavigateToUiProcessCommandProperty);
        set => SetValue(NavigateToUiProcessCommandProperty, value);
    }
    
    public static readonly BindableProperty HealthStatusProperty = BindableProperty.Create(nameof(HealthStatus), typeof(HealthStatus), typeof(HealthMonitorSummaryControl), propertyChanged:
        (bindable, _, _) =>
        {
            var control = (HealthMonitorSummaryControl)bindable;
            control.LastUpdate = DateTime.Now;
            NotifyAllPropertyChanged(control);
        });
    public HealthStatus? HealthStatus
    {
        get => (HealthStatus)GetValue(HealthStatusProperty);
        set => SetValue(HealthStatusProperty, value);
    }
    
    public DateTime LastUpdate { get; set; } = DateTime.Now;

    public string Name => HealthStatus?.SystemStatus?.MachineName ?? "Unknown";
    public double CpuUsage
    {
        get
        {
            if (HealthStatus is { SystemStatus: not null } && HealthStatus.SystemStatus.CpuTotal != 0)
            {
                return CalculateCpuUsage(HealthStatus.SystemStatus.CpuUsed, HealthStatus.SystemStatus.CpuTotal);
            }
            return 0;
        }
    }
    public TimeSpan UpTime => HealthStatus?.SystemStatus?.UpTime ?? TimeSpan.Zero;

    public string VideoStatus => HealthStatus?.VideoProcessStatus?.State ?? "Unknown";
    public int VideoPid => HealthStatus?.VideoProcessStatus?.Pid ?? 0;
    public int VideoHandle => HealthStatus?.VideoProcessStatus?.Handles ?? 0;
    public int VideoThreads => HealthStatus?.VideoProcessStatus?.Threads ?? 0;
    public long VideoWorkingRam => HealthStatus?.VideoProcessStatus?.RamWorking ?? 0;

    public double VideoCpuUsage
    {
        get
        {
            if (HealthStatus?.VideoProcessStatus != null && HealthStatus.VideoProcessStatus?.CpuTotal != 0)
            {
                return CalculateCpuUsage(HealthStatus.VideoProcessStatus.CpuUsed, HealthStatus.VideoProcessStatus.CpuTotal);
            }
            return 0;
        }
    }

    public string UiStatus => HealthStatus?.UiProcessStatus?.State ?? "Unknown";
    public int UiPid => HealthStatus?.UiProcessStatus?.Pid ?? 0;
    public int UiHandle => HealthStatus?.UiProcessStatus?.Handles ?? 0;
    public int UiThreads => HealthStatus?.UiProcessStatus?.Threads ?? 0;
    public long UiWorkingRam => HealthStatus?.UiProcessStatus?.RamWorking ?? 0;

    public double UiCpuUsage
    {
        get
        {
            if (HealthStatus?.UiProcessStatus != null && HealthStatus.UiProcessStatus.CpuTotal != 0)
            {
                return CalculateCpuUsage(HealthStatus.UiProcessStatus.CpuUsed, HealthStatus.UiProcessStatus.CpuTotal);
            }
            return 0;
        }
    }
    
    public HealthMonitorSummaryControl()
	{
		InitializeComponent();
	}
    
    
    private static void NotifyAllPropertyChanged(HealthMonitorSummaryControl control)
    {
        control.OnPropertyChanged(nameof(Name));
        control.OnPropertyChanged(nameof(CpuUsage));
        control.OnPropertyChanged(nameof(UpTime));
        control.OnPropertyChanged(nameof(VideoStatus));
        control.OnPropertyChanged(nameof(VideoPid));
        control.OnPropertyChanged(nameof(VideoHandle));
        control.OnPropertyChanged(nameof(VideoThreads));
        control.OnPropertyChanged(nameof(VideoWorkingRam));
        control.OnPropertyChanged(nameof(VideoCpuUsage));
        control.OnPropertyChanged(nameof(UiStatus));
        control.OnPropertyChanged(nameof(UiPid));
        control.OnPropertyChanged(nameof(UiHandle));
        control.OnPropertyChanged(nameof(UiThreads));
        control.OnPropertyChanged(nameof(UiWorkingRam));
        control.OnPropertyChanged(nameof(UiCpuUsage));
        control.OnPropertyChanged(nameof(LastUpdate));
    }
    
    private double CalculateCpuUsage(double used, double total)
    {
        var usage = (used / total) * 100;
        return Math.Round(usage, 2);
    }
}