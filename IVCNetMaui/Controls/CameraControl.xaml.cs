using System.ComponentModel;
using System.Windows.Input;
using CommunityToolkit.Maui.Views;
using IVCNetMaui.Models;
using IVCNetMaui.Models.IoT;
using IVCNetMaui.ViewModels.View;

namespace IVCNetMaui.Controls;

public partial class CameraControl : ContentView
{
    public CameraControl(CameraControlViewModel vm)
    {
	    BindingContext = vm;
		InitializeComponent();
	}
	private void ControlGrid_Tapped(object? sender, EventArgs e)
	{
		Task.Run(FadeInAnimation);
	}

	private async Task FadeInAnimation()
	{
		if (BindingContext is CameraControlViewModel)
		{
			if (HeaderControls.Opacity == 0)
			{
				await Task.WhenAll([
					HeaderControls.FadeTo(1, 150),
					BottomLeftControls.FadeTo(1, 150),
					BottomRightControls.FadeTo(1, 150)
				]);

			}
			else
			{
				await Task.WhenAll([
					HeaderControls.FadeTo(0, 150),
					BottomLeftControls.FadeTo(0, 150),
					BottomRightControls.FadeTo(0, 150)
				]);
			}
		}
	}
}