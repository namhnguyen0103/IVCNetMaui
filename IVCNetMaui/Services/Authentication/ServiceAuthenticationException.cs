namespace IVCNetMaui.Services.Authentication;

public class ServiceAuthenticationException : Exception
{
    public string Content { get; }
    
    public ServiceAuthenticationException(string content)
    {
        Content = content;
    }
}