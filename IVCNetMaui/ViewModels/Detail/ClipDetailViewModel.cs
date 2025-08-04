using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Views;
using IVCNetMaui.Models;
using IVCNetMaui.Services.Api;
using IVCNetMaui.Services.Navigation;
using IVCNetMaui.ViewModels.Base;

namespace IVCNetMaui.ViewModels.Detail;

[QueryProperty(nameof(Event), "Event")]
public partial class ClipDetailViewModel : ViewModelBase
{
    [ObservableProperty] private Event _event = new();
    [ObservableProperty] private MediaSource _mediaSource = MediaSource.FromFile("");
    [ObservableProperty] private MediaSource _mediaSource2 = MediaSource.FromFile("");
    public ClipDetailViewModel(INavigationService navigationService, IApiService apiService) : base(navigationService,
        apiService)
    {

    }
    
    partial void OnEventChanged(Event value)
    {
        // if (value.ClipFileName != null)
        // {
            Task.Run(async () => await GetClipAsync("6/-20250730153608808-20250730153618808.mp4"));
        // }
    }
    
    private async Task GetClipAsync(string clipFileName)
    {
        try
        {
            // var clips = clipFileName.Split(',');
            // var tasks = new List<Task<byte[]>>();
            // foreach (var clip in clips)
            // {
            //     var segments = clip.Split('/');
            //     var feed = segments[0];
            //     var filename = segments.Last();
            //     var clipName = Path.GetFileNameWithoutExtension(filename);
            //     var parameter = $"1/{feed}/{clipName}";
            //     tasks.Add(ApiService.GetClipAsync(parameter));
            // }
            // await Task.WhenAll(tasks);
            // foreach (var task in tasks)
            // {
            //     var tempPath = Path.Combine(FileSystem.CacheDirectory, "tempvideo.mp4");
            //     File.WriteAllBytes(tempPath, bytes);
            //     clipSources.Add(ImageSource.FromStream(() => new MemoryStream(task.Result)));
            // }
            var task1 = await ApiService.GetClipAsync("1/6/-20250730151808842-20250730151818842");
            var tempPath1 = Path.Combine(FileSystem.CacheDirectory, "video1.mp4");
            File.WriteAllBytes(tempPath1, task1);
            MediaSource = MediaSource.FromFile(tempPath1);
            // MediaSource.From
            var task2 = await ApiService.GetClipAsync("1/4/-20250730153246191-20250730153256191");
            var tempPath2 = Path.Combine(FileSystem.CacheDirectory, "video2.mp4");
            File.WriteAllBytes(tempPath2, task2);
            MediaSource2 = MediaSource.FromFile(tempPath2);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }

    }
}