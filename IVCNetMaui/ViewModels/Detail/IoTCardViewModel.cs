using IVCNetMaui.Models.IoT;
using IVCNetMaui.Services.Api;
using IVCNetMaui.Services.Navigation;
using IVCNetMaui.ViewModels.Base;

namespace IVCNetMaui.ViewModels.Detail;

public partial class IoTCardViewModel(string id, IoTBase iotInfo, INavigationService navigationService, IApiService apiService)
    : ViewModelBase(navigationService, apiService)
{
    [ObservableProperty] private string _id = id;
    
    [ObservableProperty] 
    [NotifyPropertyChangedFor(nameof(StatusString))]
    private IoTBase _iotInfo = iotInfo;
    
    [ObservableProperty] 
    [NotifyPropertyChangedFor(nameof(StatusString))]
    private IoTStatus _status = new();

    public string StatusString => IotInfo.Status == 0 ? Status.Status : "Deactivated";
}