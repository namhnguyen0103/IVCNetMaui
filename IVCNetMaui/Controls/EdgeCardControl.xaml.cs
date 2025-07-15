    using CommunityToolkit.Mvvm.Input;
    using IVCNetMaui.Models;

    namespace IVCNetMaui.Controls;

public partial class EdgeCardControl : ContentView
{

    public static readonly BindableProperty CommandProperty =
        BindableProperty.Create(nameof(Command), typeof(AsyncRelayCommand), typeof(EdgeCardControl));

    public AsyncRelayCommand Command
    {
        get => (AsyncRelayCommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }
    
    public static readonly BindableProperty UnitProperty =
        BindableProperty.Create(nameof(Unit), typeof(Edge), typeof(EdgeCardControl), propertyChanged:
            (bindable, _, _) =>
            {
                var control = (EdgeCardControl)bindable;
                control.OnPropertyChanged(nameof(Version));
            });

    public Edge? Unit
    {
        get => (Edge)GetValue(UnitProperty);
        set => SetValue(UnitProperty, value);
    }

    public string Version => Unit?.EdgeStatus?.Version ?? "Unknown";

    public EdgeCardControl()
	{
		InitializeComponent();
	}
}