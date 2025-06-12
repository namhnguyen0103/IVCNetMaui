using IVCNetMaui.Services.Navigation;

namespace IVCNetMaui.ViewModels;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IVCNetMaui.Views;
using System.ComponentModel;

public partial class LoginViewModel : ObservableObject
{
    public IAsyncRelayCommand LoginCommand { get; private set; }

	[ObservableProperty]
	private string username;

	[ObservableProperty]
	private string password;
	
	private readonly INavigationService _navigationService;

    public LoginViewModel(INavigationService navigationService)
	{
		_navigationService = navigationService;
		LoginCommand = new AsyncRelayCommand(OnLoginAsync);
	}

	private async Task OnLoginAsync()
	{
		Console.WriteLine("Works");

		await _navigationService.NavigateToAsync("//hub");
		// Application.Current.Windows[0].Page = new AppShell();
		// Application.Current.Windows[0].Page = new MainPage();
	}

	
}