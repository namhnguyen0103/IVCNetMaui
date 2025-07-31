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
    private ObservableCollection<CameraControlViewModel> _cameras = new();
    
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(AddCameraCommand))]
    private int _cameraCount;

    [RelayCommand(CanExecute = nameof(CanAddCamera))]
    private void AddCamera()
    {
        var newCamera = _viewModelFactoryService.GetViewModel<CameraControlViewModel>();
        newCamera.DeleteCommand = new RelayCommand(() => DeleteCamera(newCamera));
        Cameras.Add(newCamera);
        CameraCount++;
    }
        
    private bool CanAddCamera() {
        return CameraCount < 4;
    }
    
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
        AddCamera();
    }
}