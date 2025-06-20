    using CommunityToolkit.Mvvm.Input;

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

    public EdgeCardControl()
	{
		InitializeComponent();
	}
}