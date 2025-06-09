using CommunityToolkit.Mvvm.Input;

namespace IVCNetMaui.Controls;

public partial class EventCardControl : ContentView
{
    public static readonly BindableProperty CommandProperty =
    BindableProperty.Create(nameof(Command), typeof(AsyncRelayCommand), typeof(EventCardControl));

    public AsyncRelayCommand Command
    {
        get => (AsyncRelayCommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }
    public EventCardControl()
	{
		InitializeComponent();
	}
}