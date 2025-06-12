namespace IVCNetMaui.ViewModels.View;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IVCNetMaui.Controls;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

public partial class CameraViewModel : ObservableObject
{
    public List<CameraControl> Cameras { get; }

    public ICommand AddCommand { get; private set; }

    [ObservableProperty]
    int cameraCount = 1;

    // For testing if deleting and adding cameras are correct
    private int count = 1;
    public CameraViewModel()
	{
        AddCommand = new Command(AddCamera, CanAddCamera);
        Cameras = new()
        {
            new CameraControl(){ Title = "0", DeleteCommand = new Command<CameraControl>(DeleteCamera)}
        };
    }

    private void AddCamera()
    {
        Cameras.Add(new CameraControl() { Title = count.ToString(), DeleteCommand = new Command<CameraControl>(DeleteCamera) });
        count++;
        CameraCount++;
    }

    private bool CanAddCamera() {
        return CameraCount == 1;
    }

    private void DeleteCamera(CameraControl camera)
    {
        if (CameraCount <= 1) return;
        if (Cameras.Contains(camera))
        {
            Cameras.Remove(camera);
            CameraCount--;
        }
    }
}