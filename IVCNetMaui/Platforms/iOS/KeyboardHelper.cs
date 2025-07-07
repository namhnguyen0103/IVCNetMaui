#if __IOS__
using UIKit;

namespace IVCNetMaui;

public static class KeyboardHelper
{
	public static void HideKeyboard()
	{
		var window = UIKit.UIApplication.SharedApplication?.KeyWindow;
		if (window != null)
		{
			window.EndEditing(true);
		}
	}
}
#endif