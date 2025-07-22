using CommunityToolkit.Mvvm.Input;
using IVCNetMaui.Models;
using IVCNetMaui.Services.Navigation;

namespace IVCNetMaui.Controls;

public partial class EventCardControl : ContentView
{
	public static readonly BindableProperty EventProperty = BindableProperty.Create(nameof(Event), typeof(Event), typeof(EventCardControl));

	public Event Event
	{
		get => (Event)GetValue(EventProperty);
		set => SetValue(EventProperty, value);
	}
	
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