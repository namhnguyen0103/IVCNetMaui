using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IVCNetMaui.Models;
using IVCNetMaui.Services.Api;
using IVCNetMaui.Services.Dialog;
using IVCNetMaui.Services.Navigation;
using IVCNetMaui.ViewModels.Base;

namespace IVCNetMaui.ViewModels.Detail;

[QueryProperty(nameof(Event), "Event")]
public partial class EventDetailViewModel(INavigationService navigationService, IApiService apiService, IDialogService dialogService) : ViewModelBase(navigationService, apiService)
{
	public IDialogService DialogService { get; } = dialogService;
	
	[ObservableProperty]
	private Event _event = new();
	
	[RelayCommand]
	private Task NavigateToMediaDetail()
	{
		return NavigationService.NavigateToAsync("mediaDetail");
	}

	[RelayCommand]
	private async Task UploadSnap()
	{
			var result = await ApiService.PutUploadSnapAsync(5, 3, "aei-4093-cam1-20250725122914111", "jpg");
			if (result)
			{
				await DialogService.ShowAlertAsync("Upload Sucess", string.Empty, "OK");
			}
			else
			{
				await DialogService.ShowAlertAsync("Upload Failed", string.Empty, "OK");
			}
	}
}