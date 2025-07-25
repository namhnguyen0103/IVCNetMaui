using System.Text.Json;
using IVCNetMaui.Models;
using IVCNetMaui.Models.Authentication;
using IVCNetMaui.Models.IoT;
using IVCNetMaui.Models.Metric;
using IVCNetMaui.Models.Status;
using IVCNetMaui.Services.Credential;
using IVCNetMaui.Services.RequestProvider;

namespace IVCNetMaui.Services.Api;

public class ApiService : IApiService
{
    private readonly IRequestProvider  _requestProvider;
    private readonly GlobalSetting _globalSetting;

    public ApiService(IRequestProvider requestProvider, GlobalSetting globalSetting)
    {
        _requestProvider = requestProvider;
        _globalSetting = globalSetting;
    }
    
    public async Task<List<Permission>> GetPermissionsAsync()
    {
        try
        {
            var response = await _requestProvider.GetAsync<List<Permission>>($"{_globalSetting.BaseApiEndpoint}/permissions");
            Console.WriteLine("ApiService Permissions Retrieved!");
            Console.WriteLine("Response : {0}", response);
            return response;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<List<Role>> GetRoleAsync()
    {
        try
        {
            var response = 
                await _requestProvider.PostAsync<List<Role>, string[]>($"{_globalSetting.BaseApiEndpoint}/Roles/ByGroupNames", _globalSetting.ApiUserInfo.Roles);
            return response;
        }
        catch (Exception e)
        {
            Console.WriteLine("ApiService Exception Caught!");
            Console.WriteLine("Message: {0}",  e.Message);
        }

        return [];
    }

    public async Task<List<Unit>> GetVideoFeedsAsync()
    {
        try
        {
            var response = await _requestProvider.GetAsync<List<Unit>>($"{_globalSetting.BaseApiEndpoint}/video/feeds");
            Console.WriteLine("ApiService Video Retrieved!");
            Console.WriteLine("Response : {0}", response);
            return response;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<CurrentLocalApiUserInfo> GetUserInfoAsync()
    {
        try
        {
            var response =
                await _requestProvider.GetAsync<CurrentLocalApiUserInfo>(
                    $"{_globalSetting.BaseApiEndpoint}/auth/currentlocalapiuserinfo");
            Console.WriteLine("ApiService User Info Retrieved!");
            Console.WriteLine("Response : {0}", response);
            return response;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<HealthStatus> GetHealthStatusAsync()
    {
        try
        {
            var response =
                await _requestProvider.GetAsync<HealthStatus>(
                    $"{_globalSetting.BaseApiEndpoint}/health/status?appname");
            Console.WriteLine("ApiService Health Status Retrieved!");
            Console.WriteLine("Response : {0}", response);
            return response;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<List<Edge>> GetEdgesAsync()
    {
        try
        {
            var response = await _requestProvider.GetAsync<List<Edge>>($"{_globalSetting.BaseApiEndpoint}/vaedgeunit");
            return response;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<EdgeStatus> GetEdgeStatusAsync(int unit)
    {
        try
        {
            var response = await _requestProvider.GetAsync<EdgeStatus>($"{_globalSetting.BaseApiEndpoint}/vaedge/status?unit={unit}");
            return response;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<HealthStatus?> GetEdgeHealthAsync(int unit)
    {
        try
        {
            var response = await _requestProvider.GetAsync<HealthMetricRoot>($"{_globalSetting.BaseApiEndpoint}/vaedge/health/status?unit={unit}");
            var value = response.HealthMetrics;
            List<Disk> disks = new();
            if (value?.System?.DiskBytes != null)
            {
                foreach (var disk in value.System.DiskBytes)
                {
                    disks.Add(new Disk
                    {
                        DiskName = disk.Key,
                        Total = disk.Value.Total,
                        Used = disk.Value.Used,
                        Available = disk.Value.Available,
                    });
                }
            }
            
            List<Models.Metric.Network> networks = new();
            if (value?.System?.Network != null)
            {
                foreach (var network in value.System.Network.Values)
                {
                    networks.Add(new Models.Metric.Network
                    {
                        InterfaceId = network.InterfaceId,
                        Name = network.Name,
                        Description = network.Description,
                        NetworkInterfaceType = network.NetworkInterfaceType,
                        BytesSendPerSecond = network.BytesSentPerSecond,
                        BytesReceivePerSecond = network.BytesReceivedPerSecond,
                        PacketsQueued = network.PacketsQueued,
                    });
                }
            }
            
            var healthStatus = new HealthStatus()
            {
                SystemStatus = new SystemStatus
                {
                    MachineName = value?.System?.Info?.MachineName,
                    OsVersion = value?.System?.Info?.OsVersion,
                    Started = value?.System?.Info?.Started ?? new DateTime(),
                    UpTime = value?.System?.Info?.UpTime ?? TimeSpan.Zero,
                    CpuTotal = value?.System?.Cpus?.Total ?? 0,
                    CpuUsed = value?.System?.Cpus?.Used ?? 0,
                    RamPhysicalTotal = value?.System?.RamBytes?["Physical"].Total ?? 0,
                    RamPhysicalUsed = value?.System?.RamBytes?["Physical"].Used ?? 0,
                    RamVirtualTotal = value?.System?.RamBytes?["Virtual"].Total ?? 0,
                    RamVirtualUsed = value?.System?.RamBytes?["Virtual"].Used ?? 0,
                    Disks = disks.ToArray(),
                    Network = networks.ToArray(),
                },
                UiProcessStatus = new ProcessStatus
                {
                    ApplicationName = null,
                    State = value?.Vae_ui?.State,
                    Error = value?.Vae_ui?.Error,
                    Pid = value?.Vae_ui?.Pid ?? -1,
                    LastExitTime = value?.Vae_ui?.LastExitTime,
                    LastExitCode = value?.Vae_ui?.LastExitCode,
                    CpuTotal = value?.Vae_ui?.Cpus?.Total ?? 0,
                    CpuUsed = value?.Vae_ui?.Cpus?.Used ?? 0,
                    RamPeakWorking = value?.Vae_ui?.RamBytes?.PeakWorking ?? 0,
                    RamWorking = value?.Vae_ui?.RamBytes?.Working ?? 0,
                    RamPaged = value?.Vae_ui?.RamBytes?.Paged ?? 0,
                    RamPeakPaged = value?.Vae_ui?.RamBytes?.PeakPaged ?? 0,
                    Threads = value?.Vae_ui?.Threads ?? 0,
                    Handles = value?.Vae_ui?.Handles ?? 0,
                },
                VideoProcessStatus = new ProcessStatus() 
                {
                    ApplicationName = null,
                    State = value?.Vae_video?.State,
                    Error = value?.Vae_video?.Error,
                    Pid = value?.Vae_video?.Pid ?? -1,
                    LastExitTime = value?.Vae_video?.LastExitTime,
                    LastExitCode = value?.Vae_video?.LastExitCode,
                    CpuTotal = value?.Vae_video?.Cpus?.Total ?? 0,
                    CpuUsed = value?.Vae_video?.Cpus?.Used ?? 0,
                    RamPeakWorking = value?.Vae_video?.RamBytes?.PeakWorking ?? 0,
                    RamWorking = value?.Vae_video?.RamBytes?.Working ?? 0,
                    RamPaged = value?.Vae_video?.RamBytes?.Paged ?? 0,
                    RamPeakPaged = value?.Vae_video?.RamBytes?.PeakPaged ?? 0,
                    Threads = value?.Vae_video?.Threads ?? 0,
                    Handles = value?.Vae_video?.Handles ?? 0,
                }
            };
            return healthStatus;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<List<Camera>> GetCamerasAsync(int unit)
    {
        try
        {
            var response =
                await _requestProvider.GetAsync<List<Camera>>(
                    $"{_globalSetting.BaseApiEndpoint}/vaedge/iot/inventory/cameras?unit={unit}");
            return response;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<List<ModbusDevice>> GetModbusDeviceAsync(int unit)
    {
        try
        {
            var response =
                await _requestProvider.GetAsync<List<ModbusDevice>>(
                    $"{_globalSetting.BaseApiEndpoint}/vaedge/iot/inventory/modbuses?unit={unit}");
            return response;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<List<WeatherStation>> GetWeatherStationAsync(int unit)
    {
        try
        {
            var response =
                await _requestProvider.GetAsync<List<WeatherStation>>(
                    $"{_globalSetting.BaseApiEndpoint}/vaedge/iot/inventory/weatherstations?unit={unit}");
            return response;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<IoTStatus> GetIoTStatusAsync(int unit, string type, int iot)
    {
        try
        {
            var response = await _requestProvider.GetAsync<IoTStatus>($"{_globalSetting.BaseApiEndpoint}/vaedge/iot/status?unit={unit}&type={type}&iot={iot}");
            return response;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<List<Event>> GetEventsAsync(int pageNum, int pageSize)
    {
        try
        {
            var response = await _requestProvider.GetAsync<List<Event>>($"{_globalSetting.BaseApiEndpoint}/eventlog/page?pagenum={pageNum}&pagesize={pageSize}&orderby=id&direction=desc");
            return response;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<int> GetEventCountAsync()
    {
        try
        {
            var response = await _requestProvider.GetAsync<int>($"{_globalSetting.BaseApiEndpoint}/eventlog/count");
            return response;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<bool> PutUploadSnapAsync(int unit, int feed, string snapshot, string extension)
    {
        try
        {
            var response = await _requestProvider.PutAsync<string>($"{_globalSetting.BaseApiEndpoint}/api/v1/video/ui/snapshot/upload?unit=5&feed=3&snapshot=aei-4093-cam1-20250725122914111&ext=jpg");
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }
}