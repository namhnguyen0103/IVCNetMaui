namespace IVCNetMaui.Models;

public class Feed
{
    public required string FeedId { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsValid { get; set; }
    public bool IsEnabled { get; set; }
    public bool SupportsPresets { get; set; }
    public List<Preset> Presets { get; set; } = new();
    public Control Controls { get; set; } = new();
}