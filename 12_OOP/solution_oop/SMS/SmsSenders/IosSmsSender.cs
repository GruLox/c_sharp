namespace SMS.SmsSenders;

public class IosSmsSender : ISmsSender
{
    public Task SendSmsAsync(string message)
    {
        // Code to send SMS using iOS
        return Task.CompletedTask;
    }
}
