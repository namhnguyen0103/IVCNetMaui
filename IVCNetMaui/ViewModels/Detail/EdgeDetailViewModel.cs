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
    public partial class EdgeDetailViewModel : ViewModelBase
    {
        public ICommand NavigateToHealthMonitorCommand { get; private set; }
        [ObservableProperty]
        public ObservableCollection<String> cameras = new();
        public EdgeDetailViewModel(INavigationService navigationService) : base(navigationService) 
        {
            NavigateToHealthMonitorCommand = new AsyncRelayCommand(() => NavigationService.NavigateToAsync("healthMonitor"));
            Cameras.Add("Item 1");
            Cameras.Add("Item 2");
        }
    }
}
