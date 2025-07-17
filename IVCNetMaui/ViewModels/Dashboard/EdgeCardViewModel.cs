using System.Collections.ObjectModel;
using IVCNetMaui.Models;
using IVCNetMaui.Models.IoT;
using IVCNetMaui.Services.Api;
using IVCNetMaui.Services.Navigation;
using IVCNetMaui.ViewModels.Base;

namespace IVCNetMaui.ViewModels.Dashboard;

public partial class EdgeCardViewModel : ViewModelBase
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(EdgeState))]
    private Edge _edgeInfo;
    
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Version))]
    private EdgeStatus? _status;
    
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Uptime))]
    [NotifyPropertyChangedFor(nameof(VideoState))]
    [NotifyPropertyChangedFor(nameof(UiState))]
    [NotifyPropertyChangedFor(nameof(CpuUsage))]
    [NotifyPropertyChangedFor(nameof(VideoCpuUsage))]
    [NotifyPropertyChangedFor(nameof(UiCpuUsage))]
    private EdgeHealth? _health;
    
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(CameraIsVisible))]
    [NotifyPropertyChangedFor(nameof(IoTIsVisible))]
    [NotifyPropertyChangedFor(nameof(CameraActivated))]
    private ObservableCollection<Camera> _cameras = new();
    
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(ModbusDeviceIsVisible))]
    [NotifyPropertyChangedFor(nameof(IoTIsVisible))]
    [NotifyPropertyChangedFor(nameof(ModbusDeviceActivated))]
    private ObservableCollection<ModbusDevice> _modbusDevices = new() ;
    
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(WeatherStationIsVisible))]
    [NotifyPropertyChangedFor(nameof(IoTIsVisible))]
    [NotifyPropertyChangedFor(nameof(WeatherStationActivated))]
    private ObservableCollection<WeatherStation> _weatherStations = new();
    
    [RelayCommand(CanExecute = nameof(IsActive))]
    private Task NavigateToEdgeDetail()
    {
        return NavigationService.NavigateToAsync("edgeDetail");
    }

    private bool IsActive() => EdgeInfo.Status == 0;
    
    public bool HealthIsVisible => EdgeInfo.Status == 0;
    public bool IoTIsVisible => EdgeInfo.Status == 0 && (CameraIsVisible || ModbusDeviceIsVisible || WeatherStationIsVisible);
    public String EdgeState => EdgeInfo.Status == 0 ? "Active" : "Deactivated";
    public String Version => Status?.Version ?? "Unknown";
    public TimeSpan Uptime => Health?.System?.Info?.UpTime ?? TimeSpan.Zero;
    public String VideoState => Health?.Vae_video?.State ?? "Unknown";
    public String UiState => Health?.Vae_ui?.State ?? "Unknown";
    public double CpuUsage
    {
        get
        {
            if (Health?.System?.Cpus != null)
            {
                return CalculateCpuUsage(Health.System.Cpus.Used, Health.System.Cpus.Total);
            }
            return 0;
        }
    }
    public double VideoCpuUsage {
        get
        {
            if (Health?.Vae_video?.Cpus != null)
            {
                return CalculateCpuUsage(Health.Vae_video.Cpus.Used, Health.Vae_video.Cpus.Total);
            }
            return 0;
        }
    }
    public double UiCpuUsage {
        get
        {
            if (Health?.Vae_ui?.Cpus != null) 
            {
                return CalculateCpuUsage(Health.Vae_ui.Cpus.Used, Health.Vae_ui.Cpus.Total);
            }
            return 0;
        }
    }
    public bool CameraIsVisible => Cameras.Count > 0;
    public bool ModbusDeviceIsVisible => ModbusDevices.Count > 0;
    public bool WeatherStationIsVisible => WeatherStations.Count > 0;
    public int CameraActivated
    {
        get
        {
            var count = 0;
            foreach (var camera in Cameras)
            {
                if (camera.Status == 0) count++;
            }

            return count;
        }
    }
    public int ModbusDeviceActivated
    {
        get
        {
            var count = 0;
            foreach (var modbus in ModbusDevices)
            {
                if (modbus.Status == 0) count++;
            }

            return count;
        }
    }
    public int WeatherStationActivated
    {
        get
        {
            var count = 0;
            foreach (var weatherStation in WeatherStations)
            {
                if (weatherStation.Status == 0) count++;
            }

            return count;
        }
    }
    public EdgeCardViewModel(Edge edge, INavigationService navigationService, IApiService apiService) : base(navigationService, apiService)
    {
        _edgeInfo = edge;
        Task.Run(InitializeAsync);
    }

    public override async Task InitializeAsync()
    {
        if (EdgeInfo.Status == 0)
        {
            var tasks = new List<Task>()
            {
                GetStatusAsync(), 
                GetHealthAsync(),
                GetCamerasAsync(),
                GetModbusDevicesAsync(),
                GetWeatherStationsAsync(),
            };
            await Task.WhenAll(tasks);
        }
    }

    private async Task GetStatusAsync()
    {
        Status = await ApiService.GetEdgeStatusAsync(EdgeInfo.Id);
    }

    private async Task GetHealthAsync()
    {
        Health = await ApiService.GetEdgeHealthAsync(EdgeInfo.Id);
    }

    private async Task GetCamerasAsync()
    {
        var result = await ApiService.GetCamerasAsync(EdgeInfo.Id);
        Cameras = new ObservableCollection<Camera>(result);
    }
    
    private async Task GetModbusDevicesAsync()
    {
        var result = await ApiService.GetModbusDeviceAsync(EdgeInfo.Id);
        ModbusDevices = new ObservableCollection<ModbusDevice>(result);
    }
    
    private async Task GetWeatherStationsAsync()
    {
        var result = await ApiService.GetWeatherStationAsync(EdgeInfo.Id);
        WeatherStations = new ObservableCollection<WeatherStation>(result);
    }
    
    private double CalculateCpuUsage(double used, double total)
    {
        if (total == 0 || used == 0) return 0;
        var usage = (used / total) * 100;
        return Math.Round(usage, 2);
    }
}