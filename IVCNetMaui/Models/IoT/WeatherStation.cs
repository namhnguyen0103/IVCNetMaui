namespace IVCNetMaui.Models.IoT;

public class WeatherStation : IoTBase
{
    public bool SoftDeleted { get; set; }
    public bool Historicized { get; set; }
    public int WeatherServerCode { get; set; }
    public int WeatherServiceAPI { get; set; }
    public int ServiceUriScheme { get; set; }
    public string? StationId { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public string? Version { get; set; }
    public string? SerialNumber { get; set; }
    public string? MacAddress { get; set; }
    public string? ModelNumber { get; set; }
    public int PollInterval { get; set; }
    public int ASCategoryId { get; set; }
    public ASCategory ASCategory { get; set; }
    public string? Tag { get; set; }
    public string? Description { get; set; }
}

public class ASCategory
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int CategoryId { get; set; }
    public string[] ASModbusDevices { get; set; }
    public string[] ASCameras { get; set; }
    public string[] ASWeatherStations { get; set; }
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
}