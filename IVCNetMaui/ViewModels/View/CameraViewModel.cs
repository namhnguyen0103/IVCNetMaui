using IVCNetMaui.Services.Api;
using IVCNetMaui.Services.Dialog;
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
    private readonly IDialogService _dialogService;

    [ObservableProperty] 
    private ObservableCollection<CameraControlViewModel> _cameras = new();
    
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(AddCameraCommand))]
    private int _cameraCount;

    [RelayCommand(CanExecute = nameof(CanAddCamera))]
    private void AddCamera()
    {
        var newCamera = _viewModelFactoryService.GetViewModel<CameraControlViewModel>();
        newCamera.DeleteCommand = new AsyncRelayCommand( async () => await DeleteCamera(newCamera));
        Cameras.Add(newCamera);
        CameraCount++;
    }
        
    private bool CanAddCamera() {
        return CameraCount < 4;
    }
    
    private async Task DeleteCamera(CameraControlViewModel camera)
    {
        if (CameraCount <= 1) return;
        if (Cameras.Contains(camera))
        {
            var response = await _dialogService.ShowConfirmationAsync("Delete Camera", string.Empty, "OK", "Cancel");
            if (response)
            {
                Cameras.Remove(camera);
                CameraCount--;
            }
        }
    }
    
    public CameraViewModel(INavigationService navigationService, IApiService apiService, GlobalSetting globalSetting, IViewModelFactoryService viewModelFactoryService, IDialogService dialogService) : base(navigationService, apiService)
	{
        _globalSetting = globalSetting;
        _viewModelFactoryService = viewModelFactoryService;
        _dialogService = dialogService;
        AddCamera();
    }
}