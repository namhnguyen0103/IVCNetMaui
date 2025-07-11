using IVCNetMaui.Services.Navigation;
using IVCNetMaui.ViewModels.Base;
using System.Collections.ObjectModel;
using IVCNetMaui.Models.HealthStatus;
using IVCNetMaui.Services.Api;

namespace IVCNetMaui.ViewModels.Dashboard
{
    public partial class DashboardMainViewModel(INavigationService navigationService, IApiService apiService)
        : ViewModelBase(navigationService, apiService)
    {
        
        [ObservableProperty]
        private ObservableCollection<string> _list =
        [
            "LVE1", "LVE2", "LVE3", "LVE4"
        ];

        [ObservableProperty]
        private HealthStatus? _healthStatus;

        [ObservableProperty] 
        private bool _isRefreshing;

        public override async Task InitializeAsync()
        {
            await UpdateHealthStatusAsync();
        }

        [RelayCommand]
        private Task NavigateToSystem()
        {
            return IsBusyFor(NavigateToSystemAsync);
        }
        
        [RelayCommand]
        private Task NavigateToVideoProcess()
        {
            return IsBusyFor(NavigateToVideoProcessAsync);
        }
        [RelayCommand]
        private Task NavigateToUiProcess()
        {
            return IsBusyFor(NavigateToUiProcessAsync);
        }
        
        [RelayCommand]
        private async Task Refresh()
        {
            await UpdateHealthStatusAsync();
            IsRefreshing = false;
        }
        
        private async Task NavigateToSystemAsync()
        {
            // await Task.Delay(500);
            await NavigationService.NavigateToAsync("healthMonitor");
        }
        
        private async Task NavigateToVideoProcessAsync()
        {
            await NavigationService.NavigateToAsync("healthMonitor", new ShellNavigationQueryParameters()
            {
                { "InitialPage", 1 }
            });
        }
        
        private async Task NavigateToUiProcessAsync()
        {
            await NavigationService.NavigateToAsync("healthMonitor", new ShellNavigationQueryParameters()
            {
                { "InitialPage", 2 }
            });
        }

        [RelayCommand]
        private Task NavigateToEdgeDetail()
        {
            return NavigationService.NavigateToAsync("edgeDetail");
        }

        private async Task UpdateHealthStatusAsync()
        {
            try
            {
                HealthStatus = await ApiService.GetHealthStatusAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
