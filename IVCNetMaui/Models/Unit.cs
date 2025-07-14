using IVCNetMaui.Models.Authentication;

namespace IVCNetMaui.Models;

public class Unit
{
    public required string UnitId { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsValid { get; set; }
    public bool IsEnabled { get; set; }
    public Feed[] Feeds { get; set; } = [];
    public StreamingModes? StreamingModes { get; set; }
}