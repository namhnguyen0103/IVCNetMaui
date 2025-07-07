using IVCNetMaui.ViewModels.Dashboard;

namespace IVCNetMaui.Views.Dashboard;

public partial class DashboardMainPage : ContentPage
{
	public DashboardMainPage(DashboardMainViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();

		if (BindingContext is DashboardMainViewModel vm && vm.InitializeAsyncCommand.CanExecute(null))
		{
			vm.InitializeAsyncCommand.Execute(null);
		}
	}
}