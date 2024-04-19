
namespace SMS.SmsSenders;

public class AndroidSmsSender : ISmsSender
{
    public Task SendSmsAsync(string message)
    {
        // Code to send SMS using Android
        return Task.CompletedTask;
    }
}
