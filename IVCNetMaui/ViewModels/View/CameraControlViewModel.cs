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
    }

    [ObservableProperty] private ObservableCollection<Unit> _units;
    [ObservableProperty] private int _selectedUnitIndex = -1;
    [ObservableProperty] private IRelayCommand _deleteCommand;
    partial void OnSelectedUnitIndexChanged(int oldValue, int newValue)
    {
        if ((newValue == oldValue) || (newValue < 0 || newValue >= Units.Count))
        {
            return;
        }

        SelectedFeedIndex = -1;
        Feeds = new ObservableCollection<Feed>(Units[newValue].Feeds);
    }

    [ObservableProperty] private ObservableCollection<Feed> _feeds = new();
    [ObservableProperty] private int _selectedFeedIndex = -1;
    [ObservableProperty] private bool _ptzIsVisible;

    [RelayCommand]
    private void TogglePtz()
    {
        PtzIsVisible = !PtzIsVisible;
    }
}