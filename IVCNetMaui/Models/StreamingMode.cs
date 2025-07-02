namespace IVCNetMaui.Models;

public class StreamingMode
{
    public bool UseDefault { get; set; }
    public int BufferCapacity { get; set; }
    public string? FramesPerSecond { get; set; }
    public string? StalledConnectionTimeout { get; set; }
}

public class StreamingModes
{
    public required StreamingMode Live { get; set; }
    public required StreamingMode Guard { get; set; }
}