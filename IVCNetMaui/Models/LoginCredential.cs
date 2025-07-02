namespace IVCNetMaui.Models;

public class LoginCredential
{
    public required string Username { get; set; }
    public required string Password { get; set; }
    public required string Ip { get; set; }
    public required int Port { get; set; }
    public required string Type { get; set; }
}