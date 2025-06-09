using CommunityToolkit.Mvvm.Input;

namespace IVCNetMaui.Controls;

public partial class AccordionControl : ContentView
{
    public static readonly BindableProperty HeaderProperty = BindableProperty.Create(nameof(Header), typeof(String), typeof(AccordionControl), string.Empty);
    public string Header
    {
        get => (string)GetValue(HeaderProperty);
        set => SetValue(HeaderProperty, value);
    }

    public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable<String>), typeof(AccordionControl));
    public IEnumerable<String> ItemsSource
    {
        get => (IEnumerable<String>)GetValue(ItemsSourceProperty);
        set => SetValue(ItemsSourceProperty, value);
    }

    public static readonly BindableProperty ItemCommandProperty = BindableProperty.Create(nameof(ItemCommand), typeof(AsyncRelayCommand), typeof(AccordionControl));
    public AsyncRelayCommand ItemCommand
    {
        get => (AsyncRelayCommand)GetValue(ItemCommandProperty);
        set => SetValue(ItemCommandProperty, value);
    }

    public Command RotateIconCommand { get; }
    public AccordionControl()
	{
        RotateIconCommand = new Command(RotateIcon);
        InitializeComponent();
	}

    private void RotateIcon()
    {
        Console.WriteLine("Rotate works");
        HeaderIcon.RelRotateTo(180, 0);
    }
}