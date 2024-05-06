namespace SMS_Sender.MessageSenders;

public class AndroidMessageSender(IHttpService httpService) : MessageSender(httpService)
{
    protected override string Route => Constants.ANDROID_ROUTE;
    protected override char GetSeparator() => Constants.ANDROID_SEPERATOR;
}
