using CommunityToolkit.Mvvm.Input;
using IVCNetMaui.Services.Api;
using IVCNetMaui.Services.Navigation;

namespace IVCNetMaui.ViewModels.Base;

public interface IViewModelBase
{
    public INavigationService NavigationService { get; }
    
    public IApiService ApiService { get; }
    
    public IAsyncRelayCommand InitializeAsyncCommand { get; }
    
    public bool IsBusy { get; }
    
    public bool IsInitialized { get; }
    
    Task InitializeAsync();
}