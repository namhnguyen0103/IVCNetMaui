using IVCNetMaui.ViewModels.Detail;

namespace IVCNetMaui.Views.Detail;

public partial class ProcessDetailPage : ContentPage
{
	public ProcessDetailPage()
	{
		BindingContext = new ProcessDetailViewModel();
		InitializeComponent();
	}
}