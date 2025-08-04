using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IVCNetMaui.ViewModels.View;

namespace IVCNetMaui.Views.View;

public partial class EventFilterPage : ContentPage
{
    public EventFilterPage(EventViewModel vm)
    {
        BindingContext = vm;
        InitializeComponent();
        switch (vm.FilterParams.SortOrder)
        {
            case "asc":
                SortOrderCollectionView.SelectedItem = "Ascending";
                break;
            case "desc":
                SortOrderCollectionView.SelectedItem = "Descending";
                break;
            default:
                SortOrderCollectionView.SelectedItem = "Descending";
                break;
        }

        switch (vm.FilterParams.SortBy)
        {
            case "Id":
                SortByCollectionView.SelectedItem = "ID";
                break;
            default:
                SortByCollectionView.SelectedItem = "ID";
                break;
        }
    }

    private async void CancelButton_OnClicked(object? sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }

    private async void ApplyButton_OnClicked(object? sender, EventArgs e)
    {
        var sortOrder = (String)SortOrderCollectionView.SelectedItem;
        var newParams = new FilterParams();
        switch (sortOrder)
        {
            case "Ascending":
                newParams.SortOrder = "asc";
                break;
            case "Descending":
                newParams.SortOrder = "desc";
                break;
        }
        var sortBy = (String)SortByCollectionView.SelectedItem;
        switch (sortBy)
        {
            case "ID":
                newParams.SortBy = "Id";
                break;
            default:
                newParams.SortBy = "Id";
                break;
        }
        var vm = BindingContext as EventViewModel;
        vm.FilterParams =  newParams;
        await Navigation.PopModalAsync();
    }
}