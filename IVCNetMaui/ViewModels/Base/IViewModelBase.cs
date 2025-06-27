using CommunityToolkit.Mvvm.Input;
using IVCNetMaui.Services.Navigation;

namespace IVCNetMaui.ViewModels.Base;

public interface IViewModelBase
{
    public INavigationService NavigationService { get; }
    
    public IAsyncRelayCommand InitializeAsyncCommand { get; }
    
    public bool IsBusy { get; }
    
    public bool IsInitialized { get; }
    
    Task InitializeAsync();
}