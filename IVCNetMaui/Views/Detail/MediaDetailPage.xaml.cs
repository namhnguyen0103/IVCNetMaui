using IVCNetMaui.ViewModels.Detail;

namespace IVCNetMaui.Views.Detail;

public partial class MediaDetailPage : ContentPage
{
	public MediaDetailPage()
	{
		BindingContext = new MediaDetailViewModel();
		InitializeComponent();
	}
}