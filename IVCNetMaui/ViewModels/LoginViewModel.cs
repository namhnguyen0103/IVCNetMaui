using IVCNetMaui.Services.Navigation;
using IVCNetMaui.ViewModels.Base;

namespace IVCNetMaui.ViewModels;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IVCNetMaui.Views;
using System.ComponentModel;

public partial class LoginViewModel(INavigationService navigationService) : ViewModelBase(navigationService)
{
	[ObservableProperty]
	private string _username = string.Empty;

	[ObservableProperty]
	private string _password = string.Empty;

	[RelayCommand]
	private Task Login()
	{
		return NavigationService.NavigateToAsync("//dashboard");
	}
}