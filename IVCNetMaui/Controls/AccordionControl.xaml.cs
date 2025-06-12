using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace IVCNetMaui.Controls;

public partial class AccordionControl : ContentView
{
    public static readonly BindableProperty HeaderContentProperty = BindableProperty.Create(nameof(HeaderContent), typeof(ControlTemplate), typeof(AccordionControl));

    public ControlTemplate HeaderContent
    {
        get => (ControlTemplate)this.GetValue(HeaderContentProperty);
        set => SetValue(HeaderContentProperty, value);
    }
    
    public static readonly BindableProperty BodyContentProperty = BindableProperty.Create(nameof(BodyContent), typeof(ControlTemplate), typeof(AccordionControl));

    public ControlTemplate BodyContent
    {
        get => (ControlTemplate)GetValue(BodyContentProperty);
        set => SetValue(BodyContentProperty, value);
    }

    public AccordionControl()
    {
        InitializeComponent();
    }

    private async void OnExpandedChanged(object sender, EventArgs e)
    {
        if (MainExpander.IsExpanded)
        {
            await HeaderIcon.RotateTo(-180, 200, Easing.SinInOut);
        }
        else
        {
            await HeaderIcon.RotateTo(0, 200, Easing.SinInOut);
        }
    }
}