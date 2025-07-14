using IVCNetMaui.Models.HealthStatus;
using UraniumUI.Material.Controls;

namespace IVCNetMaui.Controls;

public partial class SystemDetailControl : ContentView
{
	public static readonly BindableProperty SystemStatusProperty = BindableProperty.Create(nameof(SystemStatus), typeof(SystemStatus), typeof(SystemDetailControl), propertyChanged:
		(bindable, _, _) =>
		{
			var control = (SystemDetailControl)bindable;
			control.LastUpdate = DateTime.Now;
			NotifyAllPropertyChanged(control);
		});
	public SystemStatus? SystemStatus
	{
		get => (SystemStatus)GetValue(SystemStatusProperty);
		set => SetValue(SystemStatusProperty, value);
	}
	
	public string Name => SystemStatus?.MachineName ?? "N/A";
	public string OsVersion => SystemStatus?.OsVersion ?? "N/A";
	public DateTime Started => SystemStatus?.Started ?? DateTime.MinValue;
	public TimeSpan UpTime => SystemStatus?.UpTime ?? TimeSpan.Zero;
	public double CpuTotal => SystemStatus?.CpuTotal ?? 0;
	public double CpuUsage
	{
		get
		{
			if (SystemStatus != null && SystemStatus.CpuTotal != 0)
			{
				return CalculateCpuUsage(SystemStatus.CpuUsed, SystemStatus.CpuTotal);
			}
			return 0;
		}
	}
	public long RamPhysicalTotal => SystemStatus?.RamPhysicalTotal ?? 0;
	public long RamPhysicalUsed => SystemStatus?.RamPhysicalUsed ?? 0;
	public long RamVirtualTotal => SystemStatus?.RamVirtualTotal ?? 0;
	public long RamVirtualUsed => SystemStatus?.RamVirtualUsed ?? 0;
	public List<Disk> Disks => SystemStatus?.Disks ?? [];
	public List<Models.HealthStatus.Network> Network => SystemStatus?.Network ?? [];
	public DateTime LastUpdate { get; set; } = DateTime.Now;
	
	public SystemDetailControl()
	{
		InitializeComponent();
	}
	private static void NotifyAllPropertyChanged(SystemDetailControl control)
	{
		control.OnPropertyChanged(nameof(Name));
		control.OnPropertyChanged(nameof(OsVersion));
		control.OnPropertyChanged(nameof(Started));
		control.OnPropertyChanged(nameof(UpTime));
		control.OnPropertyChanged(nameof(CpuTotal));
		control.OnPropertyChanged(nameof(CpuUsage));
		control.OnPropertyChanged(nameof(RamPhysicalTotal));
		control.OnPropertyChanged(nameof(RamPhysicalUsed));
		control.OnPropertyChanged(nameof(RamVirtualTotal));
		control.OnPropertyChanged(nameof(RamVirtualUsed));
		control.OnPropertyChanged(nameof(Disks));
		control.OnPropertyChanged(nameof(Network));
		control.OnPropertyChanged(nameof(LastUpdate));
	}
	private double CalculateCpuUsage(double used, double total)
	{
		var usage = (used / total) * 100;
		return Math.Round(usage, 2);
	}
}