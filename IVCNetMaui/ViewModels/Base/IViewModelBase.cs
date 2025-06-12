using IVCNetMaui.Services.Navigation;

namespace IVCNetMaui.ViewModels.Base;

public interface IViewModelBase
{
    public INavigationService NavigationService { get; }
}