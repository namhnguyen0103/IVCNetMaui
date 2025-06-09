namespace IVCNetMaui.ViewModels.Historical;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;

public partial class HealthDataViewModel : ObservableObject
{
    [ObservableProperty]
    public List<String> list = new List<string> { "Edge 1", "Edge 2" };
    public AsyncRelayCommand TestCommand { get; } = new AsyncRelayCommand(async () => Console.WriteLine("Navigation works"));
    public HealthDataViewModel()
	{
	}

}