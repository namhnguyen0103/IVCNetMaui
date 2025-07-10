namespace IVCNetMaui.Controls;

public partial class UsageBarControl : ContentView
{
    public static readonly BindableProperty DiskNameProperty = BindableProperty.Create(nameof(DiskName), typeof(String), typeof(UsageBarControl), string.Empty);
    public string DiskName
    {
        get => (string)GetValue(DiskNameProperty);
        set => SetValue(DiskNameProperty, value);
    }

    public static readonly BindableProperty TotalProperty = BindableProperty.Create(nameof(Total), typeof(long), typeof(UsageBarControl), propertyChanged:
        (bindable, _, _) =>
        {
            var control = (UsageBarControl)bindable;
            NotifyAllPropertyChanged(control);
        });
    public long Total
    {
        get => (long)GetValue(TotalProperty);
        set => SetValue(TotalProperty, value);
    }
    public static readonly BindableProperty UsageProperty = BindableProperty.Create(nameof(Usage), typeof(long), typeof(UsageBarControl), propertyChanged:
        (bindable, _, _) =>
        {
            var control = (UsageBarControl)bindable;
            NotifyAllPropertyChanged(control);
        });
    public long Usage
    {
        get => (long)GetValue(UsageProperty);
        set => SetValue(UsageProperty, value);
    }
    
    public double Progress
    {
        get
        {
            if (Total == 0) return 0;
            var fraction = ((double)Usage / Total) * 100;
            return fraction;
        }
    }
    
    public long Free => Total - Usage;

    public UsageBarControl()
	{
		InitializeComponent();
	}

    private static void NotifyAllPropertyChanged(UsageBarControl control)
    {
        control.OnPropertyChanged(nameof(Progress));
        control.OnPropertyChanged(nameof(Free));
    }
}