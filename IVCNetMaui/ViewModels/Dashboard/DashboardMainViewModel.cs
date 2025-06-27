using IVCNetMaui.Services.Navigation;
using IVCNetMaui.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IVCNetMaui.ViewModels.Dashboard
{
    public partial class DashboardMainViewModel(INavigationService navigationService) : ViewModelBase(navigationService)
    {
        [ObservableProperty]
        private ObservableCollection<string> _list =
        [
            "LVE1", "LVE2", "LVE3", "LVE4"
        ];
        
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
