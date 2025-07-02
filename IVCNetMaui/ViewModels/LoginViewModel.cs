using IVCNetMaui.Models;
using IVCNetMaui.Services.Api;
using IVCNetMaui.Services.Authentication;
using IVCNetMaui.Services.Navigation;
using IVCNetMaui.ViewModels.Base;

namespace IVCNetMaui.ViewModels;

public partial class LoginViewModel : ViewModelBase
{
	private readonly IAuthenticationService _authenticationService;
	
	private readonly GlobalSetting _globalSetting;
	
	[ObservableProperty]
	private string _username = string.Empty;

	[ObservableProperty]
	private string _password = string.Empty;

	[ObservableProperty]
	private string _ip = string.Empty;

	[ObservableProperty]
	private int _port;

	[ObservableProperty]
	private string _type = string.Empty;

	[ObservableProperty]
	private List<string> _longwatchType = new() { "VAH", "VAE" };

	[ObservableProperty] 
	private bool _error = false;
	
	[ObservableProperty]
	private string _errorMessage = string.Empty;

	public LoginViewModel(INavigationService navigationService, IApiService apiService, IAuthenticationService authenticationService, GlobalSetting globalSetting) : base(navigationService, apiService)
	{
		_authenticationService = authenticationService;
		_globalSetting = globalSetting;
		Type = "VAH";
	}

	partial void OnTypeChanged(string? oldValue, string newValue)
	{
		if (oldValue == newValue) return;

		Port = newValue switch
		{
			"VAH" => 7544,
			"VAE" => 7444,
			_ => Port
		};
	}

	[RelayCommand]
	private Task Login()
	{
		return IsBusyFor(LoginAsync);
	}	
	
	private async Task LoginAsync()
	{
		try
		{
			// await NavigationService.NavigateToAsync("//dashboard");
			ErrorMessage = string.Empty;
			var loginCredential = new LoginCredential
			{
				Username = Username,
				Password = Password,
				Ip = Ip,
				Port = Port,
				Type = Type
			};
			var result = await _authenticationService.LoginAsync(loginCredential);
			if (result)
			{
				_globalSetting.BaseApiEndpoint = $"http://{Ip}:{Port}/api/v1";
				_globalSetting.Permissions = await ApiService.GetPermissions();
				_globalSetting.Units = await ApiService.GetVideoFeeds();
				await NavigationService.NavigateToAsync("//dashboard");
			}
			else
			{
				ErrorMessage = "Invalid Login Credentials";
			}
		}
		catch (HttpRequestException e)
		{
			ErrorMessage = "Login Error";
			Console.WriteLine("Login Exception Caught!");
			Console.WriteLine("Message : {0} ", e.Message);
		}
	}
}