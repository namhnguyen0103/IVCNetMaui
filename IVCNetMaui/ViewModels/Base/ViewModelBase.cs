using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IVCNetMaui.Services.Api;
using IVCNetMaui.Services.Navigation;

namespace IVCNetMaui.ViewModels.Base;

public abstract partial class ViewModelBase : ObservableObject, IViewModelBase
{
    private long _isBusy;
    
    public bool IsBusy => Interlocked.Read(ref _isBusy) > 0;
    
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(InitializeAsyncCommand))]
    private bool _isInitialized;
    public INavigationService NavigationService { get; }
    public IApiService ApiService { get; }

    public IAsyncRelayCommand InitializeAsyncCommand { get; }

    public ViewModelBase(INavigationService navigationService, IApiService apiService)
    {
        NavigationService = navigationService;
        ApiService = apiService;

        InitializeAsyncCommand = 
            new AsyncRelayCommand(
                async () =>
                    {
                        await IsBusyFor(InitializeAsync);
                        IsInitialized = true;
                    }, 
                () => !IsInitialized);
    }

    public virtual Task InitializeAsync()
    {
        return Task.CompletedTask;
    }

    public async Task IsBusyFor(Func<Task> unitOfWork)
    {
        Interlocked.Increment(ref _isBusy);
        OnPropertyChanged(nameof(IsBusy));

        try
        {
            await unitOfWork();
        }
        finally
        {
            Interlocked.Decrement(ref _isBusy);
            OnPropertyChanged(nameof(IsBusy));
        }
    }
}