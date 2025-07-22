using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IVCNetMaui.Views.View;

public partial class EventFilterPage : ContentPage
{
    public EventFilterPage()
    {
        InitializeComponent();
    }

    private async void Button_OnClicked(object? sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}