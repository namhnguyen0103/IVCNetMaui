using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace IVCNetMaui.Controls;

public partial class AccordionControl : ContentView
{
    public static readonly BindableProperty HeaderProperty = BindableProperty.Create(nameof(Header), typeof(String), typeof(AccordionControl), string.Empty);
    public string Header
    {
        get => (string)GetValue(HeaderProperty);
        set => SetValue(HeaderProperty, value);
    }
    private Image? _headerIcon;
    public ICommand RotateIconCommand { get; set; }
    public AccordionControl()
	{
        RotateIconCommand = new Command(RotateIcon);
        InitializeComponent();
	}

    protected override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        _headerIcon = GetTemplateChild("HeaderIcon") as Image;
    }

    private void RotateIcon()
    {
        Console.WriteLine("Rotate works");
        _headerIcon?.RelRotateTo(180, 0);
    }
}