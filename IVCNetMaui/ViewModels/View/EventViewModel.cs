namespace IVCNetMaui.ViewModels.View;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;

public partial class EventViewModel : ObservableObject
{
    [ObservableProperty]
    public List<string> list = new List<string> { "1", "2", "3" };
    public AsyncRelayCommand GoToEventDetailCommand { get; }
    public EventViewModel()
	{
        GoToEventDetailCommand = new AsyncRelayCommand(GoToEventDetail);
    }
    private async Task GoToEventDetail()
    {
        await Shell.Current.GoToAsync("eventDetail");
    }
}