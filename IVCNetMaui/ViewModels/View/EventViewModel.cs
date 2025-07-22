using IVCNetMaui.Services.Api;
using IVCNetMaui.Services.Navigation;
using IVCNetMaui.ViewModels.Base;
using IVCNetMaui.Models;
using IVCNetMaui.Views.View;

namespace IVCNetMaui.ViewModels.View;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;

public partial class EventViewModel(INavigationService navigationService, IApiService apiService)
    : ViewModelBase(navigationService, apiService)
{
    [ObservableProperty] private ObservableCollection<Event> _events = new();

    [RelayCommand]
    private Task NavigateToEventDetail(Event data)
    {
        var queryParameters = new ShellNavigationQueryParameters()
        {
            { "Event", data }
        };
        return NavigationService.NavigateToAsync("eventDetail", queryParameters);
    }
    
    [RelayCommand]
    private Task OpenFilterPage()
    {
        return NavigationService.PushModalAsync(new EventFilterPage());
    }

    public override async Task InitializeAsync()
    {
        await Task.Delay(500);
        await GetEventsAsync();
    }

    private async Task GetEventsAsync()
    {
        try
        {
            var events = await ApiService.GetEventsAsync();
            Events = new ObservableCollection<Event>(events);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}