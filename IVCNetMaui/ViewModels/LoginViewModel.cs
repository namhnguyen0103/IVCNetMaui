namespace IVCNetMaui.ViewModels;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;

public partial class LoginViewModel : ObservableObject
{
    public IAsyncRelayCommand LoginCommand { get; }

	[ObservableProperty]
	private string username;

	[ObservableProperty]
	private string password;

    public LoginViewModel()
	{
		LoginCommand = new AsyncRelayCommand(OnLoginAsync);
	}

	private async Task OnLoginAsync()
	{
		Console.WriteLine("Works");
		Application.Current.Windows[0].Page = new AppShell();
	}

	
}