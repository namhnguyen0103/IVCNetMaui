namespace IVCNetMaui.ViewModels;
using CommunityToolkit.Mvvm;
using System.ComponentModel;

public class LoginViewModel : INotifyPropertyChanged
{
	public Command Login;

    private string _username, _password;

    public event PropertyChangedEventHandler? PropertyChanged;

    public LoginViewModel()
	{
		//Login = new Command(
		//	execute: async () => await Shell.Current.GoToAsync("//Dashboard/Hub"));
	}

	public string Username
	{
		get => _username;
		set
		{
			if (_username != value)
			{
				_username = value;
			}
		}
	}

	public string Password
	{
		get => _password;
		set
		{
			if (_password != value)
			{
				_password = value;
			}
		}
	}

	
}