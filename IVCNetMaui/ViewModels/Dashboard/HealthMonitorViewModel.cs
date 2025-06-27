using CommunityToolkit.Mvvm.ComponentModel;
using IVCNetMaui.Services.Navigation;
using IVCNetMaui.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IVCNetMaui.ViewModels.Dashboard
{
    public partial class HealthMonitorViewModel(INavigationService navigationService) : ViewModelBase(navigationService)
    {
        [ObservableProperty]
        private ObservableCollection<Network> _networks =
        [
            new() {
                Name = "eth0",
                NIT = "6",
                Send = "10.54 Kbps",
                Receive = "23.76 Kbps",
                PktQd = "0"
            }
        ];

        public class Network
        {
            public string Name { get; set; } = string.Empty;
            public string NIT { get; set; } = string.Empty;
            public string Send { get; set; } = string.Empty;
            public string Receive { get; set; } = string.Empty;
            public string PktQd { get; set; } = string.Empty;
        }
    }
}
