namespace SMS.Interfaces;

public interface ISmsSender
{
    Task SendSmsAsync(string message);
}
