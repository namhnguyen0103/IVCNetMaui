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
			if (Controls.Opacity == 0)
			{
				await Controls.FadeTo(1, 150);
			}
			else
			{
				await Controls.FadeTo(0, 150);
			}
		}
	}
}