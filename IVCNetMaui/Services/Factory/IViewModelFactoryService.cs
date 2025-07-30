namespace IVCNetMaui.Services.Factory;

public interface IViewModelFactoryService
{
    TViewModel GetViewModel<TViewModel>();
}