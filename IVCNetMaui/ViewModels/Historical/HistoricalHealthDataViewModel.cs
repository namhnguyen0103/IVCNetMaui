using IVCNetMaui.Services.Navigation;
using IVCNetMaui.ViewModels.Base;

namespace IVCNetMaui.ViewModels.Historical;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;

public partial class HistoricalHealthDataViewModel : ViewModelBase
{
    public HistoricalHealthDataViewModel(INavigationService navigationService) : base(navigationService)
	{
	}

}