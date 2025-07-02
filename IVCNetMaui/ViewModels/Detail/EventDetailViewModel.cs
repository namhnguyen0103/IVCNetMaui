using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IVCNetMaui.Services.Api;
using IVCNetMaui.Services.Navigation;
using IVCNetMaui.ViewModels.Base;

namespace IVCNetMaui.ViewModels.Detail;

public partial class EventDetailViewModel(INavigationService navigationService, IApiService apiService) : ViewModelBase(navigationService, apiService)
{
	[RelayCommand]
	private Task NavigateToMediaDetail()
	{
		return NavigationService.NavigateToAsync("mediaDetail");
	}
}