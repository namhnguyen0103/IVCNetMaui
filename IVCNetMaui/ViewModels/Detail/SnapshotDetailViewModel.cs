using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using IVCNetMaui.Models;
using IVCNetMaui.Services.Api;
using IVCNetMaui.Services.Navigation;
using IVCNetMaui.ViewModels.Base;

namespace IVCNetMaui.ViewModels.Detail;

[QueryProperty(nameof(Event), "Event")]
public partial class SnapshotDetailViewModel(INavigationService navigationService, IApiService apiService) : ViewModelBase(navigationService, apiService)
{
    [ObservableProperty] private Event _event = new();
    [ObservableProperty] ObservableCollection<ImageSource> _imageSources = new();

    partial void OnEventChanged(Event value)
    {
        if (value.SnapFileName != null)
        {
            Task.Run(async () => await GetSnapAsync(value.SnapFileName));
        }
    }
    
    private async Task GetSnapAsync(string snapFileName)
    {
        ObservableCollection<ImageSource> images = new();
        try
        {
            var snaps = snapFileName.Split(',');
            var tasks = new List<Task<byte[]>>();
            foreach (var snap in snaps)
            {
                var segments = snap.Split('/');
                var feed = segments[0];
                var filename = segments.Last();
                var snapshot = Path.GetFileNameWithoutExtension(filename);
                var parameter = $"{Event.UnitId}/{feed}/{snapshot}";
                tasks.Add(ApiService.GetSnapAsync(parameter));
            }
            await Task.WhenAll(tasks);
            foreach (var task in tasks)
            {
                images.Add(ImageSource.FromStream(() => new MemoryStream(task.Result)));
            }
            ImageSources = images;

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }

    }
};