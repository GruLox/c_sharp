namespace SMS_Sender.Interfaces;

public interface IMessageSender
{
    Task<MessageSendingResponse> SendMessageAsync(Message message);
}
