using IVCNetMaui.ViewModels;

namespace IVCNetMaui.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
	}
}