using IVCNetMaui.ViewModels.Detail;

namespace IVCNetMaui.Views.Detail;

public partial class EdgeDetailPage : ContentPage
{
	public EdgeDetailPage(EdgeDetailViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
	}
}