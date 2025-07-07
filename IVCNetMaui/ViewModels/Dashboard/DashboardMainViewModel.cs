using IVCNetMaui.Services.Navigation;
using IVCNetMaui.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using IVCNetMaui.Models.HealthStatus;
using IVCNetMaui.Services.Api;

namespace IVCNetMaui.ViewModels.Dashboard
{
    public partial class DashboardMainViewModel(INavigationService navigationService, IApiService apiService) : ViewModelBase(navigationService, apiService)
    {
        [ObservableProperty]
        private ObservableCollection<string> _list =
        [
            "LVE1", "LVE2", "LVE3", "LVE4"
        ];

        [ObservableProperty] 
        private HealthStatus _healthStatus = new HealthStatus();

        public override async Task InitializeAsync()
        {
            try
            {
                HealthStatus = await ApiService.GetHealthStatusAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Caught!");
                Console.WriteLine(e);
            }
        }
        
        [RelayCommand]
        private Task NavigateToHealthMonitor()
        {
            return NavigationService.NavigateToAsync("healthMonitor");
        }
        
        [RelayCommand]
        private Task NavigateToSystem()
        {
            return NavigationService.NavigateToAsync("healthMonitor");
        }
        
        [RelayCommand]
        private Task NavigateToProcess()
        {
            return NavigationService.NavigateToAsync("healthMonitor");
        }

        [RelayCommand]
        private Task NavigateToEdgeDetail()
        {
            return NavigationService.NavigateToAsync("edgeDetail");
        }
    }
}
