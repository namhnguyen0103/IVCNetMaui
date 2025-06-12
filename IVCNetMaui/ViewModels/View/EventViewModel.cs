using IVCNetMaui.Services.Navigation;

namespace IVCNetMaui.ViewModels.View;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;

public partial class EventViewModel : ObservableObject
{
    private readonly INavigationService _navigationService;
    
    [ObservableProperty]
    public List<string> list = new List<string> { "1", "2", "3" };
    public IRelayCommand GoToEventDetailCommand { get; private set; }
    public EventViewModel(INavigationService navigationService)
	{
        _navigationService = navigationService;
        GoToEventDetailCommand = new AsyncRelayCommand(GoToEventDetail);
    }
    private async Task GoToEventDetail()
    {
        await _navigationService.NavigateToAsync("eventDetail");
    }
}