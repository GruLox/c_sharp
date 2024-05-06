namespace SMS_Sender.MessageSenders;

public class WindowsMessageSender(IHttpService httpService) : MessageSender(httpService)
{
    protected override string Route => Constants.WINDOWS_ROUTE;
    protected override char GetSeparator() => Constants.WINDOWS_SEPERATOR;
}
