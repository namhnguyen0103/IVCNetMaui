using System.Windows.Input;

namespace IVCNetMaui.Controls;

public partial class CameraControl : ContentView
{
    public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(String), typeof(CameraControl), string.Empty);

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public static readonly BindableProperty DeleteCommandProperty =
    BindableProperty.Create(nameof(DeleteCommand), typeof(Command<CameraControl>), typeof(CameraControl));

    public Command<CameraControl> DeleteCommand
    {
        get => (Command<CameraControl>)GetValue(DeleteCommandProperty);
        set => SetValue(DeleteCommandProperty, value);
    }
    public CameraControl()
	{
		InitializeComponent();
	}
}