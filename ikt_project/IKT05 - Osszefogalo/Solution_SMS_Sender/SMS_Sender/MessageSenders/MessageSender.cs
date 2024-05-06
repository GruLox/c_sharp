
namespace SMS_Sender.MessageSenders;

public abstract class MessageSender(IHttpService httpService) : IMessageSender
{
    protected readonly IHttpService _httpService = httpService;
    protected abstract string Route { get; }

    public virtual async Task<MessageSendingResponse> SendMessageAsync(Message message)
    {
        var formattedContent = FormatContent(message, GetSeparator());
        var requestBody = new MessageRequestBody { Content = formattedContent, System = message.System };

        try
        {
            return await _httpService.SendPostRequestAsync<MessageSendingResponse>(Route, requestBody);
        }
        catch (Exception ex)
        {
            return new MessageSendingResponse { Success = false, ErrorMessage = ex.Message, DateTime = DateTime.Now.Date.ToString() };
            
        }
    }

    protected abstract char GetSeparator();

    protected virtual string FormatContent(Message message, char separator)
    {
        var formattedMessage = new StringBuilder();

        var properties = message.GetType().GetProperties();
        foreach (var property in properties)
        {
            formattedMessage.Append($"\"{property.Name}\": \"{property.GetValue(message)}\" {separator} ");
        }
        
        // Remove the last 3 characters (separator and two spaces)
        formattedMessage.Remove(formattedMessage.Length - 3, 3);
        
        return formattedMessage.ToString();
    }
}
