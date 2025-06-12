using IVCNetMaui.ViewModels.Detail;

namespace IVCNetMaui.Views.Detail;

public partial class EventDetailPage : ContentPage
{
	public EventDetailPage(EventDetailViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
	}
}