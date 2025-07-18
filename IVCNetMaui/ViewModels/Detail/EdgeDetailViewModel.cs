using IVCNetMaui.Services.Navigation;
using IVCNetMaui.ViewModels.Base;
using System.Collections.ObjectModel;
using IVCNetMaui.Models;
using IVCNetMaui.Models.IoT;
using IVCNetMaui.Services.Api;

namespace IVCNetMaui.ViewModels.Detail
{
    [QueryProperty(nameof(EdgeInfo), "EdgeInfo")]
    [QueryProperty(nameof(Status), "Status")]
    [QueryProperty(nameof(Cameras), "Cameras")]
    [QueryProperty(nameof(ModbusDevices), "ModbusDevices")]
    [QueryProperty(nameof(WeatherStations), "WeatherStations")]
    public partial class EdgeDetailViewModel(INavigationService navigationService, IApiService apiService) : ViewModelBase(navigationService, apiService)
    {
        
        [ObservableProperty] 
        [NotifyPropertyChangedFor(nameof(PageTitle))]
        private Edge? _edgeInfo;
        
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(PageTitle))]
        private EdgeStatus? _status;
        
        [ObservableProperty] 
        [NotifyPropertyChangedFor(nameof(CameraIsVisible))]
        private ObservableCollection<Camera> _cameras = new();

        
        [ObservableProperty] 
        [NotifyPropertyChangedFor(nameof(CameraActiveCount))]
        private ObservableCollection<IoTStatus> _cameraStatuses = new();

        [ObservableProperty] 
        [NotifyPropertyChangedFor(nameof(ModbusDeviceIsVisible))]
        private ObservableCollection<ModbusDevice> _modbusDevices = new();
        
        [ObservableProperty] 
        [NotifyPropertyChangedFor(nameof(ModbusDeviceActiveCount))]
        private ObservableCollection<IoTStatus> _modbusDeviceStatuses = new();
        
        [ObservableProperty] 
        [NotifyPropertyChangedFor(nameof(WeatherStationIsVisible))]
        private ObservableCollection<WeatherStation> _weatherStations = new();
        
        [ObservableProperty] 
        [NotifyPropertyChangedFor(nameof(WeatherStationActiveCount))]
        private ObservableCollection<IoTStatus> _weatherStationStatuses = new();
        public string PageTitle => $"{EdgeInfo?.Name ?? "Unknown"} [{Status?.Version ?? "0.0.0.0"}]";
        public bool CameraIsVisible => Cameras.Count > 0;
        public bool ModbusDeviceIsVisible => ModbusDevices.Count > 0;
        public bool WeatherStationIsVisible => WeatherStations.Count > 0;
        public int CameraActiveCount => CountActivated(CameraStatuses);
        public int ModbusDeviceActiveCount => CountActivated(ModbusDeviceStatuses);
        public int WeatherStationActiveCount => CountActivated(WeatherStationStatuses);
        
        async partial void OnCamerasChanged(ObservableCollection<Camera> value)
        {
            try
            {
                if (EdgeInfo != null)
                {
                    var tasks = value.Select(async camera => await ApiService.GetIoTStatusAsync(EdgeInfo.Id, "camera", camera.Id));
                    var result = await Task.WhenAll(tasks);
                    CameraStatuses = new ObservableCollection<IoTStatus>(result);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        async partial void OnModbusDevicesChanged(ObservableCollection<ModbusDevice> value)
        {
            try
            {
                if (EdgeInfo != null)
                {
                    var tasks = value.Select(async modbus => await ApiService.GetIoTStatusAsync(EdgeInfo.Id, "modbus", modbus.Id));
                    var result = await Task.WhenAll(tasks);
                    ModbusDeviceStatuses = new ObservableCollection<IoTStatus>(result);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        async partial void OnWeatherStationsChanged(ObservableCollection<WeatherStation> value)
        {
            try
            {
                if (EdgeInfo != null)
                {
                    var tasks = value.Select(async weather => await ApiService.GetIoTStatusAsync(EdgeInfo.Id, "weather", weather.Id));
                    var result = await Task.WhenAll(tasks);
                    WeatherStationStatuses = new ObservableCollection<IoTStatus>(result);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        
        [RelayCommand]
        private Task NavigateToHealthMonitor()
        {
            return NavigationService.NavigateToAsync("healthMonitor");
        }

        private int CountActivated(ObservableCollection<IoTStatus> statuses)
        {
            var count = 0;
            foreach (var status in statuses)
            {
                if (status.Status == "Up") count++;
            }

            return count;
        }
    }
}
