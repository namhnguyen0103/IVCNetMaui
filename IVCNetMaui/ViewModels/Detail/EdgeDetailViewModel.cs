using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IVCNetMaui.Controls;
using IVCNetMaui.Services.Navigation;
using IVCNetMaui.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IVCNetMaui.ViewModels.Detail
{
    public partial class EdgeDetailViewModel(INavigationService navigationService) : ViewModelBase(navigationService)
    {
        [ObservableProperty]
        private ObservableCollection<string> _cameras = 
        [
            "Camera 1",
            "Camera 2",
        ];

        [RelayCommand]
        private Task NavigateToHealthMonitor()
        {
            return NavigationService.NavigateToAsync("healthMonitor");
        }
    }
}
