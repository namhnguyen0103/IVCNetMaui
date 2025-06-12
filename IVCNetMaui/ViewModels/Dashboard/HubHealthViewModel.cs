namespace IVCNetMaui.ViewModels.Dashboard;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;

public partial class HubHeathMonitorViewModel : ObservableObject
{
	public IAsyncRelayCommand GoToSystemDetailCommand { get; private set; }
	public IAsyncRelayCommand GoToVideoProcessDetailCommand { get; private set; }
	public IAsyncRelayCommand GoToUIProcessDetailCommand { get; private set; }
    public HubHeathMonitorViewModel()
	{
		GoToSystemDetailCommand = new AsyncRelayCommand(GoToSystemDetail);
		GoToVideoProcessDetailCommand = new AsyncRelayCommand(GoToProcessDetail);
		GoToUIProcessDetailCommand = new AsyncRelayCommand(GoToProcessDetail);
	}

	private async Task GoToSystemDetail()
	{
		await Shell.Current.GoToAsync("systemDetail");
	}

	private async Task GoToProcessDetail()
	{
		await Shell.Current.GoToAsync("processDetail");
	}



}