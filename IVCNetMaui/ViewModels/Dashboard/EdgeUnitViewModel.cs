namespace IVCNetMaui.ViewModels.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;



public partial class EdgeUnitViewModel : ObservableObject
{
    [ObservableProperty]
    public List<String> list = new List<string> { "Test1", "Test2" };
    
    public EdgeUnitViewModel()
    {

    }
}
