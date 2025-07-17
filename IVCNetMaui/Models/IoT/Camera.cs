namespace IVCNetMaui.Models.IoT;

public class Camera
{
    public int Status { get; set; }
    public int CameraId { get; set; }
    public string? Name { get; set; }
    public int VideoServerCode { get; set; }
    public int VideoCodec { get; set; }
    public int AudioCodec { get; set; }
    public int VideoServerUriScheme { get; set; }
    public int VideoStreamerUriScheme { get; set; }
    public int RtspTransportScheme { get; set; }
    public string? VideoStreamerUri { get; set; }
    public string? SnapshotUri { get; set; }
    public string? IpAddress { get; set; }
    public int Port { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public int ChannelId { get; set; }
    public int StreamId { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public string? Resolution { get; set; }
    public int Fps { get; set; }
    public bool StreamSetup { get; set; }
    public bool EnableOverlay { get; set; }
    public bool EnablePrebuffer { get; set; }
    public int BufferCapacity { get; set; }
    public bool EnableDvr { get; set; }
    public int DvrSegmentMinutes { get; set; }
    public CameraPreset[] Presets { get; set; } = Array.Empty<CameraPreset>();
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
}

public class CameraPreset : Preset
{
    public int CameraId { get; set; }
    public int XPosition { get; set; }
    public int YPosition { get; set; }
    public int ZPosition { get; set; }
    public int CameraConfigId { get; set; }
}