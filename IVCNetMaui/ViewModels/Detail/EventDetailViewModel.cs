using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace IVCNetMaui.ViewModels.Detail;

public class EventDetailViewModel : ObservableObject
{
	public IAsyncRelayCommand GoToMediaDetailCommand { get; }
    public EventDetailViewModel()
	{
		GoToMediaDetailCommand = new AsyncRelayCommand(GoToMediaDetail);
	}
	private async Task GoToMediaDetail()
	{
		await Shell.Current.GoToAsync("mediaDetail");
	}
}