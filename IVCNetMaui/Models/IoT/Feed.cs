namespace IVCNetMaui.Models.IoT;

public class Feed
{
    public int FeedId { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsValid { get; set; }
    public bool IsEnabled { get; set; }
    public bool SupportsPresets { get; set; }
    public Preset[] Presets { get; set; } = [];
    public Control Controls { get; set; } = new();
    public int VaEdgeUnitId { get; set; } = -1;
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
}

public class Preset
{
    public int PresetId { get; set; }
    public string? Name { get; set; }
    public int VaEdgeFeedId { get; set; } = -1;
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
}

public class Control
{
    public bool ContinuousPanTilt { get; set; }
    public bool ContinuousZoom { get; set; }
    public bool ContinuousFocus { get; set; }
    public bool AutoFocus { get; set; }
    public bool AbsoluteFocus { get; set; }
    public bool AbsoluteZoom { get; set; }
    public bool AreaZoom { get; set; }
}

