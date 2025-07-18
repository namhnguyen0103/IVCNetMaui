namespace IVCNetMaui.Models.IoT;

public class ModbusDevice : IoTBase
{
    public bool SoftDeleted { get; set; }
    public bool Historicized { get; set; }
    public int ServerCode { get; set; }
    public int Protocol { get; set; }
    public int ComPort { get; set; }
    public int CommunicationMethod { get; set; }
    public int TransmissionMode { get; set; }
    public int Speed { get; set; }
    public int DataBits { get; set; }
    public int Parity { get; set; }
    public int StopBits { get; set; }
    public int FlowControl { get; set; }
    public int ServerId { get; set; }
    public int ObjectType { get; set; }
    public int StartAddress { get; set; }
    public int EndAddress { get; set; }
    public int PollInterval { get; set; }
    public Auxiliary[]? Auxiliaries { get; set; }
    public string? Tag { get; set; }
    public string? Description { get; set; }
}

public class Auxiliary
{
    public bool Enabled { get; set; }
    public int AuxiliaryId { get; set; }
    public string? Name { get; set; }
    public int FunctionCode { get; set; }
    public int StartAddress { get; set; }
    public int EndAddress { get; set; }
    public string? Value { get; set; }
    public string? StartAddressAlias { get; set; }
    public string? EndAddressAlias { get; set; }
    public int ASModbusDeviceId { get; set; }
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
}