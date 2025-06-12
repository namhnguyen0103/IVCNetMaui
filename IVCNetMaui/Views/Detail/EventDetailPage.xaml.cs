using IVCNetMaui.ViewModels.Detail;

namespace IVCNetMaui.Views.Detail;

public partial class EventDetailPage : ContentPage
{
	public EventDetailPage()
	{
		BindingContext = new EventDetailViewModel();
		InitializeComponent();
	}
}