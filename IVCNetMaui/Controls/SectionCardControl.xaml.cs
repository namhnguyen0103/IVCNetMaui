namespace IVCNetMaui.Controls;

public partial class SectionCardControl : ContentView
{
	public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(String), typeof(SectionCardControl), string.Empty);
    public static readonly BindableProperty IconProperty = BindableProperty.Create(nameof(Icon), typeof(String), typeof(SectionCardControl), "ellipse.png");
    public static readonly BindableProperty CountProperty = BindableProperty.Create(nameof(Count), typeof(String), typeof(SectionCardControl), string.Empty);

    public string Title
    {
        get => (string)GetValue(SectionCardControl.TitleProperty);
        set => SetValue(SectionCardControl.TitleProperty, value);
    }

    public string Icon
    {
        get => (string)GetValue(SectionCardControl.IconProperty);
        set => SetValue(SectionCardControl.IconProperty, value);
    }

    public string Count
    {
        get => (string)GetValue(SectionCardControl.CountProperty);
        set => SetValue(SectionCardControl.CountProperty, value);
    }
    public SectionCardControl()
	{
		InitializeComponent();
	}

    void OnTapGestureRecognizerTapped(object sender, TappedEventArgs args)
    {
        //Card.BackgroundColor = (Color)Application.Current.Resources["Gray300"];
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {

    }
}