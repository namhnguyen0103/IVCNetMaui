using CommunityToolkit.Mvvm.Input;
using IVCNetMaui.Controls;
using IVCNetMaui.Services.Navigation;
using IVCNetMaui.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IVCNetMaui.ViewModels.Detail
{
    public class EdgeDetailViewModel : ViewModelBase
    {
        public ICommand NavigateToHealthMonitorCommand { get; private set; }
        public EdgeDetailViewModel(INavigationService navigationService) : base(navigationService) 
        {
            NavigateToHealthMonitorCommand = new AsyncRelayCommand(() => NavigationService.NavigateToAsync("healthMonitor"));
        }
    }
}
