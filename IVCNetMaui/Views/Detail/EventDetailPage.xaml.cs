using IVCNetMaui.ViewModels.Detail;

namespace IVCNetMaui.Views.Detail;

public partial class EventDetailPage : ContentPage
{
	public EventDetailPage(EventDetailViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
	}
	
	protected override void OnAppearing()
	{
		base.OnAppearing();
		if (BindingContext is EdgeDetailViewModel vm && vm.InitializeAsyncCommand.CanExecute(null))
		{
			vm.InitializeAsyncCommand.Execute(null);
		}
	}
}