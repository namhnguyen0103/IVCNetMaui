using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IVCNetMaui.Models;
using IVCNetMaui.Services.Api;
using IVCNetMaui.Services.Dialog;
using IVCNetMaui.Services.Navigation;
using IVCNetMaui.ViewModels.Base;

namespace IVCNetMaui.ViewModels.Detail;

[QueryProperty(nameof(Event), "Event")]
public partial class EventDetailViewModel(INavigationService navigationService, IApiService apiService, IDialogService dialogService) : ViewModelBase(navigationService, apiService)
{
	private IDialogService DialogService { get; } =  dialogService;
	
	[ObservableProperty]
	private Event _event = new();

	partial void OnEventChanged(Event value)
	{
		UploadSnapCommand.NotifyCanExecuteChanged();
		UploadClipCommand.NotifyCanExecuteChanged();
	}

	private bool CanNavigateToSnapDetail()
	{
		return Event.IsSnapUploaded;
	} 
	
	[RelayCommand(CanExecute = nameof(CanNavigateToSnapDetail))]
	private Task NavigateToSnapDetail()
	{
		var queryParameters = new ShellNavigationQueryParameters()
		{
			{ "Event", Event }
		};
		return NavigationService.NavigateToAsync("snapshotDetail",  queryParameters);
	}
	
	private bool CanNavigateToClipDetail()
	{
		return Event.IsClipUploaded;
	} 
	
	[RelayCommand(CanExecute = nameof(CanNavigateToClipDetail))]
	private Task NavigateToClipDetail()
	{
		var queryParameters = new ShellNavigationQueryParameters()
		{
			{ "Event", Event }
		};
		return NavigationService.NavigateToAsync("clipDetail",  queryParameters);
	}

	private bool CanUploadSnap()
	{
		return !String.IsNullOrEmpty(Event.SnapFileName);
	}

	[RelayCommand(CanExecute = nameof(CanUploadSnap))]
	private async Task UploadSnap()
	{
		try
		{
			List<Task<bool>> tasks = new();
			if (Event.SnapFileName is not null)
			{
				var snaps = Event.SnapFileName.Split(',');
				foreach (var snap in snaps)
				{
					var segments =  snap.Split('/');
					var feed =  segments[0];
					var filename = segments.Last();
					var snapshot = Path.GetFileNameWithoutExtension(filename);
					var extension = Path.GetExtension(filename).TrimStart('.');
					tasks.Add(ApiService.PutUploadSnapAsync(Event.UnitId, int.Parse(feed), snapshot, extension));
				}
			}

			var responses = await Task.WhenAll(tasks);
			var result = responses.All(t => t);
			if (result)
			{
				Event.IsSnapUploaded = true;
				NavigateToSnapDetailCommand.NotifyCanExecuteChanged();
				await DialogService.ShowAlertAsync("Upload Snapshot Success", string.Empty, "OK");
			}
			else
			{
				await DialogService.ShowAlertAsync("Upload Snapshot Failed", string.Empty, "OK");
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			await DialogService.ShowAlertAsync("Upload Error", string.Empty, "OK");
		}
	}

	private bool CanUploadClip()
	{
		return !String.IsNullOrEmpty(Event.ClipFileName);
	}

	[RelayCommand(CanExecute = nameof(CanUploadClip))]
	private async Task UploadClip()
	{
		try
		{
			List<Task<bool>> tasks = new();
			if (Event.ClipFileName is not null)
			{
				var snaps = Event.ClipFileName.Split(',');
				foreach (var snap in snaps)
				{
					var segments =  snap.Split('/');
					var feed =  segments[0];
					var filename = segments.Last();
					var clip = Path.GetFileNameWithoutExtension(filename);
					var extension = Path.GetExtension(filename).TrimStart('.');
					tasks.Add(ApiService.PutUploadClipAsync(Event.UnitId, int.Parse(feed), clip, extension));
				}
			}

			var responses = await Task.WhenAll(tasks);
			var result = responses.All(t => t);
			if (result)
			{
				Event.IsClipUploaded = true;
				NavigateToClipDetailCommand.NotifyCanExecuteChanged();
				await DialogService.ShowAlertAsync("Upload Clip Success", string.Empty, "OK");
			}
			else
			{
				await DialogService.ShowAlertAsync("Upload Clip Failed", string.Empty, "OK");
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			await DialogService.ShowAlertAsync("Upload Error", string.Empty, "OK");
		}
	}

	private bool CanDownload()
	{
		return false;
	}

	[RelayCommand(CanExecute = nameof(CanDownload))]
	private async Task Download()
	{
		await Task.Delay(1000);
	}
}