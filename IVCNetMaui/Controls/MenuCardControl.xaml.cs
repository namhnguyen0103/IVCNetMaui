using CommunityToolkit.Mvvm.Input;
namespace IVCNetMaui.Controls;

public partial class MenuCardControl : ContentView
{
	public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(MenuCardControl), string.Empty);
    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public static readonly BindableProperty CommandProperty =
        BindableProperty.Create(nameof(Command), typeof(AsyncRelayCommand), typeof(MenuCardControl));

    public AsyncRelayCommand Command
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