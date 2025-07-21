using IVCNetMaui.ViewModels.Dashboard;

namespace IVCNetMaui.Selectors;

public class EdgeCardTemplateSelector : DataTemplateSelector
{
    public DataTemplate ActiveCardTemplate { get; set; }
    public DataTemplate DeactivatedCardTemplate { get; set; }
    
    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        if (item is EdgeCardViewModel { EdgeInfo.Status: 0 })
        {
            return ActiveCardTemplate;
        }
        return DeactivatedCardTemplate;
    }
}