namespace IVCNetMaui.ViewModels.Dashboard;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using IVCNetMaui.Services.Navigation;
using IVCNetMaui.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class EdgeUnitViewModel : ViewModelBase
{
    [ObservableProperty]
    public ObservableCollection<String> list = new ObservableCollection<String>
        {
            "LVE1", "LVE2", "LVE3", "LVE4"
        };

    public EdgeUnitViewModel(INavigationService navigationService) : base(navigationService)
    {

    }
}
