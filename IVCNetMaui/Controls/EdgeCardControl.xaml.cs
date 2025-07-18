    using System.ComponentModel;
    using CommunityToolkit.Mvvm.Input;
    using IVCNetMaui.Models;
    using IVCNetMaui.ViewModels.Dashboard;

    namespace IVCNetMaui.Controls;

public partial class EdgeCardControl : ContentView
{
    public EdgeCardControl()
	{
		InitializeComponent();
		
		BindingContextChanged += OnBindingContextChanged;
	}
    
    
	private void OnBindingContextChanged(object? sender, EventArgs e)
	{
		if (BindingContext is EdgeCardViewModel vm)
		{
			vm.PropertyChanged += OnViewModelPropertyChanged;

			// Set initial template based on current value
			ApplyTemplate(vm.HealthIsVisible);
		}
	}

	private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == nameof(EdgeCardViewModel.HealthIsVisible))
		{
			var vm = sender as EdgeCardViewModel;
			ApplyTemplate(vm is { HealthIsVisible: true });
		}
	}

	private void ApplyTemplate(bool healthIsVisible)
	{
		ControlTemplate newTemplate = healthIsVisible
			? (ControlTemplate)this.Resources["Active"]
			: (ControlTemplate)this.Resources["Deactivated"];

		this.ControlTemplate = newTemplate;
	}
}