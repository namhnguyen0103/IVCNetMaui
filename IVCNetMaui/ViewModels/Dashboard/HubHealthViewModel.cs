namespace IVCNetMaui.ViewModels.Dashboard;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.ComponentModel;

public partial class HubHeathViewModel : ObservableObject
{
    [ObservableProperty]
    public List<String> sections;

    public HubHeathViewModel()
	{
        sections = new List<String> { "Health Monitors", "Edge Devices" };
	}



}