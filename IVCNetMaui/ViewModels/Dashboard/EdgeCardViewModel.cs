using IVCNetMaui.Models;
using IVCNetMaui.Services.Api;
using IVCNetMaui.Services.Navigation;
using IVCNetMaui.ViewModels.Base;

namespace IVCNetMaui.ViewModels.Dashboard;

public partial class EdgeCardViewModel : ViewModelBase
{
    [ObservableProperty]
    private Edge _edgeInfo;
    
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Version))]
    [NotifyPropertyChangedFor(nameof(SystemState))]
    private EdgeStatus? _status;
    
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(VideoState))]
    [NotifyPropertyChangedFor(nameof(UiState))]
    private EdgeHealth? _health;
    
    [RelayCommand]
    private Task NavigateToEdgeDetail()
    {
        return NavigationService.NavigateToAsync("edgeDetail");
    }
    
    public String Version => Status?.Version ?? "Unknown";
    public String SystemState => EdgeInfo.Status == 1 ? "Active" : "Deactivated";
    public String VideoState => Health?.Vae_video?.State ?? "Unknown";
    public String UiState => Health?.Vae_ui?.State ?? "Unknown";

    public EdgeCardViewModel(Edge edge, INavigationService navigationService, IApiService apiService) : base(navigationService, apiService)
    {
        _edgeInfo = edge;
        Task.Run(InitializeAsync);
    }

    public override async Task InitializeAsync()
    {
        var tasks = new List<Task>() { GetStatusAsync(), GetHealthAsync() };
        await Task.WhenAll(tasks);
    }

    private async Task GetStatusAsync()
    {
        Status = await ApiService.GetEdgeStatusAsync(EdgeInfo.Id);
    }

    private async Task GetHealthAsync()
    {
        Health = await ApiService.GetEdgeHealthAsync(EdgeInfo.Id);
        Console.WriteLine(Health);
    }
}