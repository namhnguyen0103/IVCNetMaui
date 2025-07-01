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
    [ObservableProperty] private ObservableCollection<string> _list;

    [RelayCommand]
    private Task NavigateToEventDetail()
    {
        return NavigationService.NavigateToAsync("eventDetail");
    }
    public EventViewModel(INavigationService navigationService) : base(navigationService)
	{
    }

    public override async Task InitializeAsync()
    {
        Console.WriteLine("InitializeAsync");
        await Task.Delay(2000);
        List = new()
        {
            "1", "2", "3"
        };
        Console.WriteLine("Completed");
    }
}