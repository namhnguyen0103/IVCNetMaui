namespace IVCNetMaui.Models.Authentication;

public class StreamingMode
{
    public bool UseDefault { get; set; }
    public int BufferCapacity { get; set; }
    public string? FramesPerSecond { get; set; }
    public string? StalledConnectionTimeout { get; set; }
}

public class StreamingModes
{
    public StreamingMode? Live { get; set; }
    public StreamingMode? Guard { get; set; }
}