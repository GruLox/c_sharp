namespace SMS.SmsSenders;

public class WindowsSmsSender : ISmsSender
{
    public Task SendSmsAsync(string message)
    {
        // Code to send SMS using Windows
        return Task.CompletedTask;
    }
}
