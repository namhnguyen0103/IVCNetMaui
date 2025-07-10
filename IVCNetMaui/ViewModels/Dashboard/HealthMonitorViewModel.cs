using IVCNetMaui.Services.Navigation;
using IVCNetMaui.ViewModels.Base;
using System.Collections.ObjectModel;
using IVCNetMaui.Models.HealthStatus;
using IVCNetMaui.Services.Api;

namespace IVCNetMaui.ViewModels.Dashboard
{
    [QueryProperty(nameof(InitialPage), "InitialPage")]
    public partial class HealthMonitorViewModel(INavigationService navigationService, IApiService apiService) : ViewModelBase(navigationService, apiService)
    {
        [ObservableProperty]
        private int _initialPage;
        
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(SystemStatus))]
        [NotifyPropertyChangedFor(nameof(VideoProcessStatus))]
        [NotifyPropertyChangedFor(nameof(UiProcessStatus))]
        private HealthStatus? _healthStatus;
        
        public SystemStatus? SystemStatus => HealthStatus?.SystemStatus;
        public ProcessStatus? VideoProcessStatus => HealthStatus?.VideoProcessStatus;
        public ProcessStatus? UiProcessStatus => HealthStatus?.UiProcessStatus;
        
        public override async Task InitializeAsync()
        {
            await UpdateHealthStatusAsync();
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
        
    }
}
