using CommunityToolkit.Mvvm.Input;

namespace IVCNetMaui.Controls;

public partial class MenuCardControl : ContentView
{
	public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(String), typeof(MenuCardControl), string.Empty);
    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    //public static readonly BindableProperty IconProperty = BindableProperty.Create(nameof(Icon), typeof(String), typeof(MenuCardControl), "ellipse.png");
    //public string Icon
    //{
    //    get => (string)GetValue(IconProperty);
    //    set => SetValue(IconProperty, value);
    //}
    //public static readonly BindableProperty CountProperty = BindableProperty.Create(nameof(Count), typeof(String), typeof(MenuCardControl), string.Empty);
    //public string Count
    //{
    //    get => (string)GetValue(CountProperty);
    //    set => SetValue(CountProperty, value);
    //}

    public static readonly BindableProperty CommandProperty =
        BindableProperty.Create(nameof(Command), typeof(IAsyncRelayCommand), typeof(MenuCardControl));

    public IAsyncRelayCommand Command
    {
        get => (AsyncRelayCommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    public static readonly BindableProperty BodyContentProperty = BindableProperty.Create(nameof(BodyContent), typeof(ControlTemplate), typeof(MenuCardControl));

    public ControlTemplate BodyContent
    {
        get => (ControlTemplate)GetValue(BodyContentProperty);
        set => SetValue(BodyContentProperty, value);
    }

    public MenuCardControl()
	{
		InitializeComponent();
	}
}