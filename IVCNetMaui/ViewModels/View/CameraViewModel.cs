using IVCNetMaui.Models;
using IVCNetMaui.Services.Api;
using IVCNetMaui.Services.Navigation;
using IVCNetMaui.ViewModels.Base;

namespace IVCNetMaui.ViewModels.View;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IVCNetMaui.Controls;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

public partial class CameraViewModel : ViewModelBase
{
    private GlobalSetting _globalSetting;
    public List<CameraControl> Cameras { get; }

    // public ICommand AddCommand { get; private set; }

    [ObservableProperty]
    private int _cameraCount = 1;

    // For testing if deleting and adding cameras are correct
    // private int _count = 1;
    public CameraViewModel(INavigationService navigationService, IApiService apiService, GlobalSetting globalSetting) : base(navigationService, apiService)
	{
        // AddCommand = new Command(AddCamera, CanAddCamera);
        _globalSetting = globalSetting;
        Cameras = 
        [
            new CameraControl()
            {
                Units = new List<Unit>(_globalSetting.Units)
            }
        ];
    }

    // private void AddCamera()
    // {
    //     Cameras.Add(new CameraControl() { Title = _count.ToString(), DeleteCommand = new Command<CameraControl>(DeleteCamera) });
    //     _count++;
    //     CameraCount++;
    // }
    //
    // private bool CanAddCamera() {
    //     return CameraCount == 1;
    // }
    //
    // private void DeleteCamera(CameraControl camera)
    // {
    //     if (CameraCount <= 1) return;
    //     if (Cameras.Contains(camera))
    //     {
    //         Cameras.Remove(camera);
    //         CameraCount--;
    //     }
    // }
}