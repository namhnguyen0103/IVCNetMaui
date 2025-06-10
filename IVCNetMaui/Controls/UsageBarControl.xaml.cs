namespace IVCNetMaui.Controls;

public partial class UsageBarControl : ContentView
{
    public static readonly BindableProperty DiskNameProperty = BindableProperty.Create(nameof(DiskName), typeof(String), typeof(UsageBarControl), string.Empty);
    public string DiskName
    {
        get => (string)GetValue(DiskNameProperty);
        set => SetValue(DiskNameProperty, value);
    }

    public static readonly BindableProperty DiskCapacityProperty = BindableProperty.Create(nameof(DiskCapacity), typeof(String), typeof(UsageBarControl), string.Empty);
    public string DiskCapacity
    {
        get => (string)GetValue(DiskCapacityProperty);
        set => SetValue(DiskCapacityProperty, value);
    }
    public static readonly BindableProperty DiskUsageProperty = BindableProperty.Create(nameof(DiskUsage), typeof(String), typeof(UsageBarControl), string.Empty);
    public string DiskUsage
    {
        get => (string)GetValue(DiskUsageProperty);
        set => SetValue(DiskUsageProperty, value);
    }
    public UsageBarControl()
	{
		InitializeComponent();
	}
}