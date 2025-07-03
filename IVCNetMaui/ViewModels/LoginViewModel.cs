using IVCNetMaui.Models;
using IVCNetMaui.Services.Api;
using IVCNetMaui.Services.Authentication;
using IVCNetMaui.Services.Navigation;
using IVCNetMaui.ViewModels.Base;

namespace IVCNetMaui.ViewModels;

public partial class LoginViewModel : ViewModelBase
{
	private readonly IAuthenticationService _authenticationService;
	private readonly IServiceProvider _serviceProvider;
	private readonly GlobalSetting _globalSetting;
	
	[ObservableProperty]
	private string _username = "admin";

	[ObservableProperty]
	private string _password = "admin.123";

	[ObservableProperty]
	private string _ip = "192.168.25.42";

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

	public LoginViewModel(INavigationService navigationService, IApiService apiService, IAuthenticationService authenticationService, GlobalSetting globalSetting,
		IServiceProvider serviceProvider) : base(navigationService, apiService)
	{
		_authenticationService = authenticationService;
		_serviceProvider = serviceProvider;
		_globalSetting = globalSetting;
		Type = "VAH";
		Port = 7181;
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
				_globalSetting.Permissions = await ApiService.GetPermissionsAsync();
				_globalSetting.Units = await ApiService.GetVideoFeedsAsync();
				Application.Current.MainPage = _serviceProvider.GetRequiredService<AppShell>();;
				// await NavigationService.NavigateToAsync("//dashboard");
			}
			else
			{
				ErrorMessage = "Invalid Login Credentials";
			}
		}
		catch (Exception ex)
		{
			ErrorMessage = "Login Error";
			Console.WriteLine("Login Exception Caught!");
			Console.WriteLine("Message : {0} ", ex.Message);
		}
	}

	private void ManageAccess()
	{
		
	}
}