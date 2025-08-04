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
            case "UnitName":
                SortByCollectionView.SelectedItem = "Unit";
                break;
            case "EventCategory":
                SortByCollectionView.SelectedItem = "Category";
                break;
            case "EventTime":
                SortByCollectionView.SelectedItem = "Event Time";
                break;
            case "EventReceived":
                SortByCollectionView.SelectedItem = "Received Time";
                break;
            case "EventRuleName":
                SortByCollectionView.SelectedItem = "Name";
                break;
            case "EventRuleTag":
                SortByCollectionView.SelectedItem = "Tag";
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
            case "Unit":
                newParams.SortBy = "UnitName";
                break;
            case "Category":
                newParams.SortBy = "EventCategory";
                break;
            case "Event Time":
                newParams.SortBy = "EventTime";
                break;
            case "Received Time":
                newParams.SortBy = "EventReceived";
                break;
            case "Name":
                newParams.SortBy = "EventRuleName";
                break;
            case "Tag":
                newParams.SortBy = "EventRuleTag";
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