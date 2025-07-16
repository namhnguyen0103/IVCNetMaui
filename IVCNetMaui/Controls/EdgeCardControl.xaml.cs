    using CommunityToolkit.Mvvm.Input;
    using IVCNetMaui.Models;
    using IVCNetMaui.ViewModels.Dashboard;

    namespace IVCNetMaui.Controls;

public partial class EdgeCardControl : ContentView
{
    public EdgeCardControl()
	{
		InitializeComponent();
		
		if (BindingContext is EdgeCardViewModel vm && vm.InitializeAsyncCommand.CanExecute(null))
		{
			vm.InitializeAsyncCommand.Execute(null);
		}
	}
}