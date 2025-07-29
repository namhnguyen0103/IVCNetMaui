using IVCNetMaui.Services.Navigation;
using IVCNetMaui.ViewModels.Detail;

namespace IVCNetMaui.Views.Detail;

public partial class SnapshotDetailPage : ContentPage
{
	public SnapshotDetailPage(SnapshotDetailViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
	}
	
	protected override void OnAppearing()
	{
		base.OnAppearing();

		if (BindingContext is SnapshotDetailViewModel vm && vm.InitializeAsyncCommand.CanExecute(null))
		{
			vm.InitializeAsyncCommand.Execute(null);
		}
	}
}