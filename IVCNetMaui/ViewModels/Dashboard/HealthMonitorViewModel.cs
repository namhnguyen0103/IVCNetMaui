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
    public partial class HealthMonitorViewModel : ViewModelBase
    {
        [ObservableProperty]
        public ObservableCollection<Network> networks = new ObservableCollection<Network>
        {
            new() {
                Name = "eth0",
                NIT = "6",
                Send = "10.54 Kbps",
                Receive = "23.76 Kbps",
                PktQd = "0"
            }
        };
        public HealthMonitorViewModel(INavigationService navigationService) : base(navigationService)
        {

        }

        public class Network
        {
            public string Name { get; set; }
            public string NIT { get; set; }
            public string Send { get; set; }
            public string Receive { get; set; }
            public string PktQd { get; set; }
        }
    }
}
