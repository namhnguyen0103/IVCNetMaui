using IVCNetMaui.Models;
using IVCNetMaui.Views.Dashboard;

namespace IVCNetMaui.Views;

public partial class MainPage : FlyoutPage
{
    //public List<FlyoutPageItem> FlyoutItems { get; set; }
    public String CurrentSelection { get; set; }
	public MainPage()
	{
        CurrentSelection = "Hub Health Monitor";
        //FlyoutItems = new List<FlyoutPageItem>
        //{
        //    new FlyoutPageItem { Title = "Hub Health Monitor", IconSource = "home.png", TargetType = typeof(HubHealthMonitorPage) }
        //};
        InitializeComponent();
        //flyoutPage.collectionView.SelectionChanged += OnSelectionChanged;
    }

    //void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    //{
    //    var item = e.CurrentSelection.FirstOrDefault() as FlyoutPageItem;
    //    if (item != null)
    //    {
    //        Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
    //        if (!((IFlyoutPageController)this).ShouldShowSplitMode)
    //            IsPresented = false;
    //    }
    //}
}