using CommunityToolkit.Mvvm.ComponentModel;
using IVCNetMaui.Services.Navigation;

namespace IVCNetMaui.ViewModels.Base;

public abstract partial class ViewModelBase : ObservableObject, IViewModelBase
{
    public INavigationService NavigationService { get; }

    public ViewModelBase(INavigationService navigationService)
    {
        NavigationService = navigationService;
    }
}