namespace IVCNetMaui.Models;

public class Event
{
    public string? EventRuleName { get; set; }
    public string? EventRuleDescription { get; set; }
    public string? EventRuleTag { get; set; }
    public string? ClipCamId { get; set; }
    public string? ClipCamName { get; set; }
    public string? ClipFileName { get; set; }
    public string? SnapCamId { get; set; }
    public string? SnapCamName { get; set; }
    public string? SnapFileName { get; set; }
    public bool IsSnapUploaded { get; set; }
    public bool IsClipUploaded { get; set; }
    public int UnitId { get; set; } = -1;
    public string? UnitName { get; set; }
    public int EdgeDeviceId { get; set; } = -1;
    public string? EdgeDeviceName { get; set; }
    public string? BusinessUnit { get; set; }
    public string? Region { get; set; }
    public string? Facility { get; set; }
    public string? Site { get; set; }
    public string? Device { get; set; }
    public string? Latitude { get; set; }
    public string? Longitude { get; set; }
    public string? EventCategory { get; set; }
    public string? EventType { get; set; }
    public string? EventTrigger { get; set; }
    public int EventId { get; set; } = -1;
    public DateTime EventTime { get; set; }
    public DateTime EventReceived { get; set; }
    public string? EventDescription { get; set; }
    public string? EventData { get; set; }
    public int Id { get; set; } = -1;
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
}