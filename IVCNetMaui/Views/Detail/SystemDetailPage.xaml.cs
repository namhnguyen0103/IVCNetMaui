using IVCNetMaui.ViewModels.Detail;

namespace IVCNetMaui.Views.Detail;

public partial class SystemDetailPage : ContentPage
{
	public SystemDetailPage()
	{
		BindingContext = new SystemDetailViewModel();
		InitializeComponent();
	}
}