using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IVCNetMaui.ViewModels.Detail;

namespace IVCNetMaui.Views.Detail;

public partial class ClipDetailPage : ContentPage
{
    public ClipDetailPage(ClipDetailViewModel vm)
    {
        BindingContext = vm;
        InitializeComponent();
    }
}