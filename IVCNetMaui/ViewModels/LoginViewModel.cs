using IVCNetMaui.Services.Authentication;
using IVCNetMaui.Services.Navigation;
using IVCNetMaui.ViewModels.Base;

namespace IVCNetMaui.ViewModels;

public partial class LoginViewModel : ViewModelBase
{
	private readonly IAuthenticationService _authenticationService;
	
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

	public LoginViewModel(INavigationService navigationService, IAuthenticationService authenticationService) : base(navigationService)
	{
		_authenticationService = authenticationService;
		Type = "VAH";
	}

	partial void OnTypeChanged(string? oldValue, string newValue)
	{
		if (oldValue == newValue) return;
		else if (newValue == "VAH")
			Port = 7544;
		else if (newValue == "VAE")
			Port = 7444;
	}

	[RelayCommand]
	private async Task Login()
	{
		try
		{
			Console.WriteLine(await _authenticationService.LoginAsync(Username, Password, Ip, Port, Type));
			await NavigationService.NavigateToAsync("//dashboard");
		}
		catch (HttpRequestException e)
		{
			Console.WriteLine("\nException Caught!");
			Console.WriteLine("Message : {0} ", e.Message);
		}
	}
}