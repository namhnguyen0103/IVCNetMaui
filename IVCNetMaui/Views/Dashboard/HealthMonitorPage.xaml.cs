using IVCNetMaui.ViewModels.Dashboard;

namespace IVCNetMaui.Views.Dashboard;

public partial class HealthMonitorPage : ContentPage
{
	public HealthMonitorPage(HealthMonitorViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
	}
	
	protected override void OnAppearing()
	{
		base.OnAppearing();

		if (BindingContext is HealthMonitorViewModel vm && vm.InitializeAsyncCommand.CanExecute(null))
		{
			vm.InitializeAsyncCommand.Execute(null);
		}
	}
}