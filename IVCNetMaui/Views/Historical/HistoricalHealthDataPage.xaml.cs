using IVCNetMaui.ViewModels.Historical;

namespace IVCNetMaui.Views.Historical;

public partial class HistoricalHealthDataPage : ContentPage
{
	public HistoricalHealthDataPage(HistoricalHealthDataViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
	}
}