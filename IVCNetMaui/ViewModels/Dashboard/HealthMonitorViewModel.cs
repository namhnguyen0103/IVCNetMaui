using IVCNetMaui.Services.Navigation;
using IVCNetMaui.ViewModels.Base;
using System.Collections.ObjectModel;
using IVCNetMaui.Services.Api;

namespace IVCNetMaui.ViewModels.Dashboard
{
    [QueryProperty(nameof(InitialPage), "InitialPage")]
    public partial class HealthMonitorViewModel(INavigationService navigationService, IApiService apiService) : ViewModelBase(navigationService, apiService)
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
        
        [ObservableProperty]
        private int _initialPage;

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
