using IVCNetMaui.ViewModels.Dashboard;

namespace IVCNetMaui.Views.Dashboard;

public partial class HubHealthMonitorPage : ContentPage
{
	public HubHealthMonitorPage(HubHealthMonitorViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
	}
}