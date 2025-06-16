using IVCNetMaui.ViewModels.Dashboard;

namespace IVCNetMaui.Views.Dashboard;

public partial class HealthMonitorPage : ContentPage
{
	public HealthMonitorPage(HubHealthMonitorViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
	}
}