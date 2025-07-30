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
        var uri = $"{_globalSetting.BaseApiEndpoint}/permissions";
        var response = await _requestProvider.GetAsync<List<Permission>>(uri);
        return response;
    }

    public async Task<List<Role>> GetRoleAsync()
    {
        var uri = $"{_globalSetting.BaseApiEndpoint}/Roles/ByGroupNames";
        var response = await _requestProvider.PostAsync<List<Role>, string[]>(uri, _globalSetting.ApiUserInfo.Roles);
        return response;
    }

    public async Task<List<Unit>> GetVideoFeedsAsync()
    {
        var uri = $"{_globalSetting.BaseApiEndpoint}/video/feeds";
        var response = await _requestProvider.GetAsync<List<Unit>>(uri);
        return response;
    }

    public async Task<CurrentLocalApiUserInfo> GetUserInfoAsync()
    {
        var uri = $"{_globalSetting.BaseApiEndpoint}/auth/currentlocalapiuserinfo";
        var response = await _requestProvider.GetAsync<CurrentLocalApiUserInfo>( uri);
        return response;
    }

    public async Task<HealthStatus> GetHealthStatusAsync()
    {
        var uri = $"{_globalSetting.BaseApiEndpoint}/health/status?appname";
        var response = await _requestProvider.GetAsync<HealthStatus>( uri);
        return response;
    }

    public async Task<List<Edge>> GetEdgesAsync()
    {
        var uri = $"{_globalSetting.BaseApiEndpoint}/vaedgeunit";
        var response = await _requestProvider.GetAsync<List<Edge>>($"{_globalSetting.BaseApiEndpoint}/vaedgeunit");
        return response;
    }

    public async Task<EdgeStatus> GetEdgeStatusAsync(int unit)
    {
        var uri = $"{_globalSetting.BaseApiEndpoint}/vaedge/status?unit={unit}";
        var response = await _requestProvider.GetAsync<EdgeStatus>($"{_globalSetting.BaseApiEndpoint}/vaedge/status?unit={unit}");
        return response;
    }

    public async Task<HealthStatus?> GetEdgeHealthAsync(int unit)
    {
        var uri = $"{_globalSetting.BaseApiEndpoint}/vaedge/health/status?unit={unit}";
        var response = await _requestProvider.GetAsync<HealthMetricRoot>(uri);
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

    public async Task<List<Camera>> GetCamerasAsync(int unit)
    {
        var uri = $"{_globalSetting.BaseApiEndpoint}/vaedge/iot/inventory/cameras?unit={unit}";
        var response = await _requestProvider.GetAsync<List<Camera>>(uri);
        return response;
    }

    public async Task<List<ModbusDevice>> GetModbusDeviceAsync(int unit)
    {
        var uri = $"{_globalSetting.BaseApiEndpoint}/vaedge/iot/inventory/modbuses?unit={unit}";
        var response = await _requestProvider.GetAsync<List<ModbusDevice>>(uri);
        return response;
    }

    public async Task<List<WeatherStation>> GetWeatherStationAsync(int unit)
    {
        var uri = $"{_globalSetting.BaseApiEndpoint}/vaedge/iot/inventory/weatherstations?unit={unit}";
        var response = await _requestProvider.GetAsync<List<WeatherStation>>(uri);
        return response;
        
    }

    public async Task<IoTStatus> GetIoTStatusAsync(int unit, string type, int iot)
    {
        var uri = $"{_globalSetting.BaseApiEndpoint}/vaedge/iot/status?unit={unit}&type={type}&iot={iot}";
        var response = await _requestProvider.GetAsync<IoTStatus>(uri);
        return response;
    }

    public async Task<List<Event>> GetEventsAsync(int pageNum, int pageSize)
    {
        var uri = $"{_globalSetting.BaseApiEndpoint}/eventlog/page?pagenum={pageNum}&pagesize={pageSize}&orderby=id&direction=desc";
        var response = await _requestProvider.GetAsync<List<Event>>(uri);
        return response;
    }

    public async Task<int> GetEventCountAsync()
    {
        var uri = $"{_globalSetting.BaseApiEndpoint}/eventlog/count";
        var response = await _requestProvider.GetAsync<int>(uri);
        return response;
    }

    public async Task<bool> PutUploadSnapAsync(int unit, int feed, string snapshot, string extension)
    {
        try
        {
            var uri = $"{_globalSetting.BaseApiEndpoint}/video/ui/snapshot/upload?unit={unit}&feed={feed}&snapshot={snapshot}&ext={extension}"; 
            await _requestProvider.PutAsync(uri);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }

    public async Task<bool> PutUploadClipAsync(int unit, int feed, string clip, string extension)
    {
        try
        {
            var uri = $"{_globalSetting.BaseApiEndpoint}/video/ui/clip/upload?unit={unit}&feed={feed}&clip={clip}&ext={extension}"; 
            await _requestProvider.PutAsync(uri);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }

    public async Task<byte[]> GetSnapAsync(string snapshot)
    {
        var uri = $"{_globalSetting.BaseApiEndpoint}/video/snapshot?snapshot={snapshot}";
        var response = await _requestProvider.GetAsync<byte[]>(uri);
        return response;
    }

    public async Task<byte[]> GetClipAsync(string clip)
    {
        var uri = $"{_globalSetting.BaseApiEndpoint}/video/clip/download?clip={clip}";
        var response = await _requestProvider.GetAsync<byte[]>(uri);
        return response;
    }
}