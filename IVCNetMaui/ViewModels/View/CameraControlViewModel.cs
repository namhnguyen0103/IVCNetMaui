using System.Collections.ObjectModel;
using IVCNetMaui.Models;
using IVCNetMaui.Models.IoT;
using IVCNetMaui.Services.Api;
using IVCNetMaui.Services.Navigation;
using IVCNetMaui.ViewModels.Base;

namespace IVCNetMaui.ViewModels.View;

public partial class CameraControlViewModel : ViewModelBase
{
    private readonly GlobalSetting _globalSetting;
    
    public CameraControlViewModel(INavigationService navigationService, IApiService apiService, GlobalSetting globalSetting) : base(navigationService, apiService)
    {
        _globalSetting = globalSetting;
        Units = new ObservableCollection<Unit>(_globalSetting.Units);
        if (Units.Count > 0)
        {
            Feeds = new(Units[0].Feeds);
        }
        else
        {
            Feeds = new();
        }
    }

    [ObservableProperty] private ObservableCollection<Unit> _units;
    [ObservableProperty] private ObservableCollection<Feed> _feeds;
}