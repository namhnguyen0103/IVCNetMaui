using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IVCNetMaui.Services.Navigation;
using IVCNetMaui.ViewModels.Base;

namespace IVCNetMaui.ViewModels.Detail;

public partial class EventDetailViewModel(INavigationService navigationService) : ViewModelBase(navigationService)
{
	[RelayCommand]
	private Task NavigateToMediaDetail()
	{
		return NavigationService.NavigateToAsync("mediaDetail");
	}
}