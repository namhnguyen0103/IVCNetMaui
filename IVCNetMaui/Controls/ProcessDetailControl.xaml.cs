using IVCNetMaui.Models.HealthStatus;

namespace IVCNetMaui.Controls;

public partial class ProcessDetailControl : ContentView
{
	public static readonly BindableProperty ProcessStatusProperty = BindableProperty.Create(nameof(ProcessStatus), typeof(ProcessStatus), typeof(ProcessDetailControl), propertyChanged:
		(bindable, _, _) =>
		{
			var control = (ProcessDetailControl)bindable;
			control.LastUpdate = DateTime.Now;
			NotifyAllPropertyChanged(control);
		});
	public ProcessStatus? ProcessStatus
	{
		get => (ProcessStatus)GetValue(ProcessStatusProperty);
		set => SetValue(ProcessStatusProperty, value);
	}

	public int Pid => ProcessStatus?.Pid ?? 0;
	public string State => ProcessStatus?.State ?? "Unknown";
	public int Threads => ProcessStatus?.Threads ?? 0;
	public int Handles => ProcessStatus?.Handles ?? 0;
	public double CpuTotal => ProcessStatus?.CpuTotal ?? 0;
	public double CpuUsage
	{
		get
		{
			if (ProcessStatus != null && ProcessStatus.CpuTotal != 0)
			{
				return CalculateCpuUsage(ProcessStatus.CpuUsed, ProcessStatus.CpuTotal);
			}
			return 0;
		}
	}
	public long RamWorking => ProcessStatus?.RamWorking ?? 0;
	public long RamPeakWorking => ProcessStatus?.RamPeakWorking ?? 0;
	
	public DateTime LastUpdate { get; set; } = DateTime.Now;

	public ProcessDetailControl()
	{
		InitializeComponent();
	}
	
	private static void NotifyAllPropertyChanged(ProcessDetailControl control)
	{
		control.OnPropertyChanged(nameof(Pid));
		control.OnPropertyChanged(nameof(State));
		control.OnPropertyChanged(nameof(Threads));
		control.OnPropertyChanged(nameof(Handles));
		control.OnPropertyChanged(nameof(CpuTotal));
		control.OnPropertyChanged(nameof(CpuUsage));
		control.OnPropertyChanged(nameof(RamWorking));
		control.OnPropertyChanged(nameof(RamPeakWorking));
		control.OnPropertyChanged(nameof(LastUpdate));
	}
	
	private double CalculateCpuUsage(double used, double total)
	{
		var usage = (used / total) * 100;
		return Math.Round(usage, 2);
	}
}