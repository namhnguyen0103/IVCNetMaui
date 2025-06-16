    using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
    public partial class DashboardMainViewModel : ViewModelBase
    {
        [ObservableProperty]
        public ObservableCollection<String> list = new ObservableCollection<String>
        {
            "LVE1", "LVE2", "LVE3", "LVE4",
            //"LVE1", "LVE2", "LVE3", "LVE4",
            //"LVE1", "LVE2", "LVE3", "LVE4",
            //"LVE1", "LVE2", "LVE3", "LVE4",
            //"LVE1", "LVE2", "LVE3", "LVE4",
            //"LVE1", "LVE2", "LVE3", "LVE4",
        };

        public ICommand ToggleFlyoutCommand { get; private set; }
        public ICommand NavigateToSystemCommand { get; private set; }
        public ICommand NavigateToProcessCommand { get; private set; }
        public DashboardMainViewModel(INavigationService navigationService) : base(navigationService) 
        {
            ToggleFlyoutCommand = new RelayCommand(() => NavigationService.TapFlyoutIcon());
            NavigateToSystemCommand = new AsyncRelayCommand(() => NavigationService.NavigateToAsync("healthMonitor"));
            NavigateToProcessCommand = new AsyncRelayCommand(() => NavigationService.NavigateToAsync("healthMonitor"));
        }
    }
}
