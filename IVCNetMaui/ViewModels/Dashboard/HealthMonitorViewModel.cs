using IVCNetMaui.Services.Navigation;
using IVCNetMaui.ViewModels.Base;
using IVCNetMaui.Models.Status;
using IVCNetMaui.Services.Api;

namespace IVCNetMaui.ViewModels.Dashboard
{
    [QueryProperty(nameof(InitialPage), "InitialPage")]
    public partial class HealthMonitorViewModel : ViewModelBase
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
        
        public AsyncRelayCommand RefreshCommand { get; }
        
        public override async Task InitializeAsync()
        {
            await UpdateHealthStatusAsync();
        }
        
        private async Task UpdateHealthStatusAsync()
        {
            try
            {
                await Task.Delay(1000);
                HealthStatus = await ApiService.GetHealthStatusAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public HealthMonitorViewModel(INavigationService navigationService, IApiService apiService) : base(
            navigationService, apiService)
        {
            RefreshCommand = new AsyncRelayCommand(async () => await IsBusyFor(UpdateHealthStatusAsync));
        }
        
    }
}
