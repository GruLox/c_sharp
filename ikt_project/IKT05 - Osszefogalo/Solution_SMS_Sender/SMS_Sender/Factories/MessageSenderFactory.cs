
namespace SMS_Sender.Factories;

public class MessageSenderFactory(IHttpService httpService) : IMessageSenderFactory
{
    private readonly IHttpService _httpService = httpService;

    public IMessageSender GetMessageSender(MobileOperatingSystem platform)
    {
        return platform switch
        {
            MobileOperatingSystem.Windows => new WindowsMessageSender(_httpService),
            MobileOperatingSystem.iOS => new IOSMessageSender(_httpService),
            MobileOperatingSystem.Android => new AndroidMessageSender(_httpService),
            _ => throw new ArgumentException("Invalid platform")
        };
    }

    
}
