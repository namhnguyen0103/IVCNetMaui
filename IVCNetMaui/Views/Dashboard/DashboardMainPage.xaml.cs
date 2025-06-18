using IVCNetMaui.ViewModels.Dashboard;

namespace IVCNetMaui.Views.Dashboard;

public partial class DashboardMainPage : ContentPage
{
	public DashboardMainPage(DashboardMainViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
	}
}