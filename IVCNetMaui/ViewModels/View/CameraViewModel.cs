using IVCNetMaui.Services.Api;
using IVCNetMaui.Services.Factory;
using IVCNetMaui.Services.Navigation;
using IVCNetMaui.ViewModels.Base;

namespace IVCNetMaui.ViewModels.View;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

public partial class CameraViewModel : ViewModelBase
{
    private readonly GlobalSetting _globalSetting;
    private readonly IViewModelFactoryService _viewModelFactoryService;

    [ObservableProperty] 
    private ObservableCollection<CameraControlViewModel> _cameras;
    
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(AddCameraCommand))]
    private int _cameraCount = 1;

    [RelayCommand(CanExecute = nameof(CanAddCamera))]
    private void AddCamera()
    {
        Cameras.Add(_viewModelFactoryService.GetViewModel<CameraControlViewModel>());
        CameraCount++;
    }
        
    private bool CanAddCamera() {
        return CameraCount < 4;
    }
    
    [RelayCommand]
    private void DeleteCamera(CameraControlViewModel camera)
    {
        if (CameraCount <= 1) return;
        if (Cameras.Contains(camera))
        {
            Cameras.Remove(camera);
            CameraCount--;
        }
    }
    
    public CameraViewModel(INavigationService navigationService, IApiService apiService, GlobalSetting globalSetting, IViewModelFactoryService viewModelFactoryService) : base(navigationService, apiService)
	{
        _globalSetting = globalSetting;
        _viewModelFactoryService = viewModelFactoryService;
        Cameras = 
        [
            _viewModelFactoryService.GetViewModel<CameraControlViewModel>(),
        ];
    }
}