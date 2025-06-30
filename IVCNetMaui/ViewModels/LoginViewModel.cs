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

	public LoginViewModel(INavigationService navigationService, IAuthenticationService authenticationService) : base(navigationService)
	{
		_authenticationService = authenticationService;
	}

	[RelayCommand]
	private async Task Login()
	{
		try
		{
			Console.WriteLine(await _authenticationService.LoginAsync(Username, Password));
		}
		catch (HttpRequestException e)
		{
			Console.WriteLine("\nException Caught!");
			Console.WriteLine("Message : {0} ", e.Message);
		}
	}
}