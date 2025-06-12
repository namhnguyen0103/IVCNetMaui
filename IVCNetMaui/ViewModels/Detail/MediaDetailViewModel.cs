using CommunityToolkit.Mvvm.ComponentModel;
using IVCNetMaui.Services.Navigation;
using IVCNetMaui.ViewModels.Base;

namespace IVCNetMaui.ViewModels.Detail;

public class MediaDetailViewModel : ViewModelBase
{
	public MediaDetailViewModel(INavigationService navigationService) : base(navigationService)
	{
	}
}