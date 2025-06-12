using IVCNetMaui.ViewModels.Dashboard;

namespace IVCNetMaui.Views.Dashboard;

public partial class HubHealthMonitorPage : ContentPage
{
	public HubHealthMonitorPage(HubHealthMonitorViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
	}

    private void OnOpenSidebarClicked(object sender, EventArgs e)
    {
        // Open the sidebar (Flyout)
        Shell.Current.FlyoutIsPresented = true;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {

    }
}