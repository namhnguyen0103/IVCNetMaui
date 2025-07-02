using CommunityToolkit.Mvvm.ComponentModel;
using IVCNetMaui.Services.Api;
using IVCNetMaui.Services.Navigation;
using IVCNetMaui.ViewModels.Base;

namespace IVCNetMaui.ViewModels.Detail;

public class MediaDetailViewModel(INavigationService navigationService, IApiService apiService) : ViewModelBase(navigationService, apiService)
{
    
};