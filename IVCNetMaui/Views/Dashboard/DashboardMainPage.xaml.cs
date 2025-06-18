using IVCNetMaui.ViewModels.Dashboard;

namespace IVCNetMaui.Views.Dashboard;

public partial class DashboardHubMainPage : ContentPage
{
	public DashboardHubMainPage(DashboardMainViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
	}
}