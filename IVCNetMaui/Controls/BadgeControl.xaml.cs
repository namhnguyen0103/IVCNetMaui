using System.Windows.Input;

namespace IVCNetMaui.Controls;

public partial class BadgeControl : ContentView
{
	public static readonly BindableProperty StatusProperty = BindableProperty.Create(nameof(Status), typeof(String), typeof(BadgeControl), string.Empty);

    public string Status
	{
        get => (string)GetValue(BadgeControl.StatusProperty);
        set => SetValue(BadgeControl.StatusProperty, value);
    }

    public BadgeControl()
	{
		InitializeComponent();
	}
}