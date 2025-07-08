namespace IVCNetMaui.Controls;

public partial class SystemDetailControl : ContentView
{
	private bool _hasLoaded = false;
	public SystemDetailControl()
	{
		InitializeComponent();
	}

	private void LazyLoad(object? sender, EventArgs e)
	{
		if (IsVisible && !_hasLoaded)
		{
			_hasLoaded = true;
		}
	}
}