using IVCNetMaui.Services.Api;
using IVCNetMaui.Services.Navigation;
using IVCNetMaui.ViewModels.Base;
using IVCNetMaui.Models;
using IVCNetMaui.Models.IoT;
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
    private int _pageNum = 1;
    
    [ObservableProperty] private ObservableCollection<Event> _events = new();
    [ObservableProperty] private bool _isRefreshing;
    [ObservableProperty] private FilterParams _filterParams = new();
    partial void OnFilterParamsChanged(FilterParams? oldValue, FilterParams newValue)
    {
        if (oldValue == null || (oldValue.SortBy != newValue.SortBy || oldValue.SortOrder != newValue.SortOrder))
        {
            _ = IsBusyFor(RefreshEvents);
        }
    }

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
    private async Task OpenFilterPage()
    {
        await NavigationService.PushModalAsync(new EventFilterPage(this));
    }

    [RelayCommand]
    private async Task LoadAdditionalEvents()
    {
        var newEvents = await GetEventsAsync();
        Events = new ObservableCollection<Event>(Events.Concat(newEvents));
    }

    [RelayCommand]
    private async Task RefreshEvents()
    {
        _pageNum = 1;
        var events = await GetEventsAsync();
        Events = new ObservableCollection<Event>(events);
        await Task.Delay(1000);
        IsRefreshing = false;
    }

    public override async Task InitializeAsync()
    {
        Events = new ObservableCollection<Event>(await GetEventsAsync()); 
    }

    private async Task<List<Event>> GetEventsAsync()
    {
        try
        {
            var events = await ApiService.GetEventsAsync(_pageNum, 25, FilterParams.SortBy, FilterParams.SortOrder);
            _pageNum++;
            return events;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new();
        }
    }
}

public class FilterParams
{
    public string SortOrder { get; set; } = "desc";
    public string SortBy { get; set; } = "Id";

    public FilterParams Copy()
    {
        return new FilterParams()
        {
            SortOrder = this.SortOrder,
            SortBy = this.SortBy,
        };
    }
}