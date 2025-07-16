using IVCNetMaui.Services.Navigation;
using IVCNetMaui.ViewModels.Base;
using System.Collections.ObjectModel;
using IVCNetMaui.Models;
using IVCNetMaui.Models.Status;
using IVCNetMaui.Services.Api;

namespace IVCNetMaui.ViewModels.Dashboard
{
    public partial class DashboardMainViewModel(INavigationService navigationService, IApiService apiService)
        : ViewModelBase(navigationService, apiService)
    {

        [ObservableProperty] private ObservableCollection<Edge> _vaEdgeUnits = [];
        [ObservableProperty] private ObservableCollection<EdgeCardViewModel> _vaEdgeCards = [];
        [ObservableProperty] private HealthStatus? _healthStatus;
        [ObservableProperty] private bool _isRefreshing;
        [ObservableProperty] private bool _hubInitializing = true;
        [ObservableProperty] private bool _edgeInitializing = true;

        public override async Task InitializeAsync()
        {
            var tasks = new List<Task>()
            {
                Task.Run(async () =>
                {
                    await UpdateHealthStatusAsync();
                    HubInitializing = false;
                }),
                Task.Run(async () =>
                {
                    await UpdateEdgesAsync();
                    EdgeInitializing = false;
                })
            };
            await Task.WhenAll(tasks);
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

        private async Task UpdateEdgesAsync()
        {
            try
            {
                var edges = await ApiService.GetEdgesAsync();
                var edgesViewModels = edges.Select((edge) => new EdgeCardViewModel(edge, NavigationService, ApiService));
                // VaEdgeUnits = new ObservableCollection<Edge>(edges);
                VaEdgeCards = new ObservableCollection<EdgeCardViewModel>(edgesViewModels);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
