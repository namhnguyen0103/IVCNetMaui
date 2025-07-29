using IVCNetMaui.Models;
using IVCNetMaui.Services.Api;
using IVCNetMaui.Services.Navigation;
using IVCNetMaui.ViewModels.Base;

namespace IVCNetMaui.ViewModels.Detail;

[QueryProperty(nameof(Event), "Event")]
public partial class ClipDetailViewModel : ViewModelBase
{
    [ObservableProperty] private Event _event = new();
    
    public ClipDetailViewModel(INavigationService navigationService, IApiService apiService) : base(navigationService, apiService)
    {
    }
}