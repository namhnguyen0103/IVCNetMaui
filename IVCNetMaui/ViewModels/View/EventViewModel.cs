using IVCNetMaui.Services.Navigation;
using IVCNetMaui.ViewModels.Base;

namespace IVCNetMaui.ViewModels.View;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;

public partial class EventViewModel : ViewModelBase
{
    [ObservableProperty]
    private List<string> _list =
        [
            "1", 
            "2", 
            "3" 
        ];
    public IRelayCommand GoToEventDetailCommand { get; private set; }

    [RelayCommand]
    private Task NavigateToEventDetail()
    {
        return NavigationService.NavigateToAsync("eventDetail");
    }
    public EventViewModel(INavigationService navigationService) : base(navigationService)
	{
    }
}