namespace IVCNetMaui.Controls;

public partial class StatusIconControl : ContentView
{
	public static readonly BindableProperty StatusProperty = BindableProperty.Create(nameof(Status), typeof(String), typeof(StatusIconControl), string.Empty);
    public static readonly BindableProperty StatusColorProperty = BindableProperty.Create(nameof(StatusColor), typeof(Color), typeof(StatusIconControl), (Color)Application.Current.Resources["Gray300"]);

    public string Status
	{
        get => (string)GetValue(StatusIconControl.StatusProperty);
        set => SetValue(StatusIconControl.StatusProperty, value);
    }

    public Color StatusColor
    {
        get => (Color)GetValue(StatusIconControl.StatusColorProperty);
        set => SetValue(StatusIconControl.StatusColorProperty, value);
    }
    public StatusIconControl()
	{
		InitializeComponent();
	}
}