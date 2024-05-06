namespace SMS_Sender.Interfaces;

public interface IMessageSenderFactory
{
    IMessageSender GetMessageSender(MobileOperatingSystem platform);
}
