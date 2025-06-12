using IVCNetMaui.ViewModels.View;

namespace IVCNetMaui.Views.View;

public partial class EventPage : ContentPage
{
	public EventPage(EventViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
	}
}