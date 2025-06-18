using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace IVCNetMaui.Controls;

public partial class HeathMonitorSummaryControl : ContentView
{
    public static readonly BindableProperty NavigateToSystemCommandProperty =
        BindableProperty.Create(nameof(NavigateToSystemCommand), typeof(ICommand), typeof(HeathMonitorSummaryControl));

    public AsyncRelayCommand NavigateToSystemCommand
    {
        get => (AsyncRelayCommand)GetValue(NavigateToSystemCommandProperty);
        set => SetValue(NavigateToSystemCommandProperty, value);
    }
    public HeathMonitorSummaryControl()
	{
		InitializeComponent();
	}
}