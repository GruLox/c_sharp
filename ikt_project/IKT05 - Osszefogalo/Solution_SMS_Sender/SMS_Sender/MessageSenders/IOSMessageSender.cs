namespace SMS_Sender.MessageSenders;

public class IOSMessageSender(IHttpService httpService) : MessageSender(httpService)
{
    protected override string Route => Constants.IOS_ROUTE;
    protected override char GetSeparator() => Constants.IOS_SEPERATOR;
}
