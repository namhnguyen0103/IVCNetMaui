using System.Net;
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
	private async Task Login()
	{
		// HttpClientHandler handler = new HttpClientHandler
		// {
		// 	Credentials = new CredentialCache
		// 	{
		// 		{
		// 			new Uri("http://192.168.25.42:7181"), // URI of the server
		// 			"Digest",
		// 			new NetworkCredential("admin", "admin.123")
		// 		}
		// 	}
		// };
		HttpClient client = new HttpClient();
		try
		{
			string responseBody = await client.GetStringAsync("http://192.168.25.42:7181/api/v1/version");
			Console.WriteLine(responseBody);
		}
		catch (HttpRequestException e)
		{
			Console.WriteLine("\nException Caught!");
			Console.WriteLine("Message :{0} ", e.Message);
		}
		// finally
		// {
		// 	await NavigationService.NavigateToAsync("//dashboard");
		// }
		


	}
}