using IVCNetMaui.Services.Navigation;
using IVCNetMaui.ViewModels.Detail;

namespace IVCNetMaui.Views.Detail;

public partial class MediaDetailPage : ContentPage
{
	public MediaDetailPage(MediaDetailViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
	}
}