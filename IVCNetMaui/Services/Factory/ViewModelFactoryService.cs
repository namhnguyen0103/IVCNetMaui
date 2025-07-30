namespace IVCNetMaui.Services.Factory;

public class ViewModelFactoryService(IServiceProvider serviceProvider) : IViewModelFactoryService
{
    public TViewModel GetViewModel<TViewModel>()
    {
        var vm =  serviceProvider.GetService<TViewModel>();
        if (vm == null)
        {
            throw new Exception("ViewModel not found");
        }

        return vm;
    }
}