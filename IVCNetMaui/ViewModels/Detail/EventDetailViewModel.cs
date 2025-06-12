using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IVCNetMaui.Services.Navigation;
using IVCNetMaui.ViewModels.Base;

namespace IVCNetMaui.ViewModels.Detail;

public class EventDetailViewModel : ViewModelBase
{
	public IAsyncRelayCommand GoToMediaDetailCommand { get; }
    public EventDetailViewModel(INavigationService navigationService) : base(navigationService)
    {
		GoToMediaDetailCommand = new AsyncRelayCommand(GoToMediaDetail);
	}
	private async Task GoToMediaDetail()
	{
		await NavigationService.NavigateToAsync("mediaDetail");
	}
}