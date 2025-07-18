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
        [NotifyPropertyChangedFor(nameof(ModbusDeviceIsVisible))]
        private ObservableCollection<ModbusDevice> _modbusDevices = new();
        
        [ObservableProperty] 
        [NotifyPropertyChangedFor(nameof(WeatherStationIsVisible))]
        private ObservableCollection<WeatherStation> _weatherStations = new();

        [ObservableProperty]
        private ObservableCollection<IoTCardViewModel> _cameraViewModels = new();
        [ObservableProperty]
        private ObservableCollection<IoTCardViewModel> _modbusDeviceViewModels = new();
        [ObservableProperty]
        private ObservableCollection<IoTCardViewModel> _weatherStationViewModels = new();
        
        public string PageTitle => $"{EdgeInfo?.Name ?? "Unknown"} [{Status?.Version ?? "0.0.0.0"}]";
        public bool CameraIsVisible => Cameras.Count > 0;
        public bool ModbusDeviceIsVisible => ModbusDevices.Count > 0;
        public bool WeatherStationIsVisible => WeatherStations.Count > 0;
        [ObservableProperty]
        private int _cameraActiveCount;
        [ObservableProperty]
        private int _modbusDeviceActiveCount;
        [ObservableProperty]
        private int _weatherStationActiveCount;
        
        async partial void OnCamerasChanged(ObservableCollection<Camera> value)
        {
            try
            {
                if (EdgeInfo != null)
                {
                    var active = 0;
                    var tasks = value.Select(async camera =>
                    {
                        var viewModel = new IoTCardViewModel(camera, navigationService, apiService);
                        if (camera.Status == 0)
                        {
                            ++active;
                            var status = await ApiService.GetIoTStatusAsync(EdgeInfo.Id, "camera", camera.Id);
                            viewModel.Status = status;
                        }

                        return viewModel;
                    });
                    CameraViewModels = new ObservableCollection<IoTCardViewModel>(await Task.WhenAll(tasks));
                    CameraActiveCount = active;
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
                    var active = 0;
                    var tasks = value.Select(async modbus =>
                    {
                        var viewModel = new IoTCardViewModel(modbus, navigationService, apiService);
                        if (modbus.Status == 0)
                        {
                            ++active;
                            var status = await ApiService.GetIoTStatusAsync(EdgeInfo.Id, "modbus", modbus.Id);
                            viewModel.Status = status;
                        }

                        return viewModel;
                    });
                    ModbusDeviceViewModels = new ObservableCollection<IoTCardViewModel>(await Task.WhenAll(tasks));
                    ModbusDeviceActiveCount = active;
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
                    var active = 0;
                    var tasks = value.Select(async weather =>
                    {
                        var viewModel = new IoTCardViewModel(weather, navigationService, apiService);
                        if (weather.Status == 0)
                        {
                            ++active;
                            var status = await ApiService.GetIoTStatusAsync(EdgeInfo.Id, "weather", weather.Id);
                            viewModel.Status = status;
                        }

                        return viewModel;
                    });
                    WeatherStationViewModels = new ObservableCollection<IoTCardViewModel>(await Task.WhenAll(tasks));
                    WeatherStationActiveCount = active;
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
    }
}
