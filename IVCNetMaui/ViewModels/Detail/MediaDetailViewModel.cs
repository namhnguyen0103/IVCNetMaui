using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using IVCNetMaui.Models;
using IVCNetMaui.Services.Api;
using IVCNetMaui.Services.Navigation;
using IVCNetMaui.ViewModels.Base;

namespace IVCNetMaui.ViewModels.Detail;

[QueryProperty(nameof(Event), "Event")]
public partial class MediaDetailViewModel(INavigationService navigationService, IApiService apiService) : ViewModelBase(navigationService, apiService)
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

    [ObservableProperty]
    private ImageSource _source = ImageSource.FromFile("placeholder.png");
    
    private async Task GetSnapAsync(string snapFileName)
    {
        try
        {
            var snaps = snapFileName.Split(',');
            foreach (var snap in snaps)
            {
                var segments = snap.Split('/');
                var feed = segments[0];
                var filename = segments.Last();
                var snapshot = Path.GetFileNameWithoutExtension(filename);
                var parameter = $"{Event.UnitId}/{feed}/{snapshot}";
                var stream = await ApiService.GetSnapAsync(parameter);
                ImageSources.Add(ImageSource.FromStream(() => stream));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }

    }
};