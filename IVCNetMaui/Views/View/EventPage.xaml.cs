using IVCNetMaui.ViewModels.View;

namespace IVCNetMaui.Views.View;

public partial class EventPage : ContentPage
{
	public EventPage(EventViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();

		if (BindingContext is EventViewModel vm && vm.InitializeAsyncCommand.CanExecute(null))
		{
			vm.InitializeAsyncCommand.Execute(null);
		}
	}
}