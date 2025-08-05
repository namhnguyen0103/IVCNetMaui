using IVCNetMaui.ViewModels;

namespace IVCNetMaui.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
	}

	private void Page_Clicked(object sender, EventArgs e)
	{
		if (DeviceInfo.Platform == DevicePlatform.iOS)
		{
#if IOS
			KeyboardHelper.HideKeyboard();
#endif
		}
	}

	private void Button_HapticFeedback(object? sender, EventArgs e)
	{
		HapticFeedback.Default.Perform(HapticFeedbackType.Click);
	}
}
