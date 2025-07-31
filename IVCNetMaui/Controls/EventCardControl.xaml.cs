using CommunityToolkit.Mvvm.Input;
using IVCNetMaui.Models;
using IVCNetMaui.Services.Navigation;

namespace IVCNetMaui.Controls;

public partial class EventCardControl : ContentView
{
	public static readonly BindableProperty EventProperty = BindableProperty.Create(nameof(Event), typeof(Event), typeof(EventCardControl),  propertyChanged:
		(bindable, _, _) =>
		{
			var control = (EventCardControl)bindable;
			control.OnPropertyChanged(nameof(MediaText));
			control.OnPropertyChanged(nameof(MediaChipIsVisible));
			control.OnPropertyChanged(nameof(SnapshotChipIsVisible));
			control.OnPropertyChanged(nameof(ClipChipIsVisible));
		});

	public Event? Event
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

	public string MediaText
	{
		get
		{
			if (Event != null)
			{
				return !String.IsNullOrEmpty(Event.ClipFileName) || !String.IsNullOrEmpty(Event.SnapFileName)
					? "Yes"
					: "No";
			}
			return "Unknown";
		}
	}
	
	public bool MediaChipIsVisible => Event != null && (!String.IsNullOrEmpty(Event.ClipFileName) || !String.IsNullOrEmpty(Event.SnapFileName));
    public bool SnapshotChipIsVisible => Event != null && !String.IsNullOrEmpty(Event.SnapFileName);
    public bool ClipChipIsVisible => Event != null && !String.IsNullOrEmpty(Event.ClipFileName);
}