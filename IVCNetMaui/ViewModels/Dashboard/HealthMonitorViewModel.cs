using IVCNetMaui.Services.Navigation;
using IVCNetMaui.ViewModels.Base;
using IVCNetMaui.Models.Status;
using IVCNetMaui.Services.Api;

namespace IVCNetMaui.ViewModels.Dashboard
{
    [QueryProperty(nameof(InitialPage), "InitialPage")]
    [QueryProperty(nameof(Type), "Type")]
    [QueryProperty(nameof(Id), "Id")]
    [QueryProperty(nameof(HealthStatus), "Health")]
    public partial class HealthMonitorViewModel : ViewModelBase
    {
        public string? Type { get; set; }
        public int Id { get; set; } = -1;
        
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
            if (HealthStatus == null) await UpdateHealthStatusAsync();
            await Task.Delay(500);
        }
        
        private async Task UpdateHealthStatusAsync()
        {
            try
            {
                if (Type == "Hub")
                {
                    HealthStatus = await ApiService.GetHealthStatusAsync();
                }
                else if (Type == "Edge")
                {
                    HealthStatus = await ApiService.GetEdgeHealthAsync(Id);
                }
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
