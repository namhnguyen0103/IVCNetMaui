using IVCNetMaui.ViewModels.Dashboard;

namespace IVCNetMaui.Views.Dashboard;

public partial class IoTListPage : ContentPage
{
	public IoTListPage(IoTListViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
	}
}