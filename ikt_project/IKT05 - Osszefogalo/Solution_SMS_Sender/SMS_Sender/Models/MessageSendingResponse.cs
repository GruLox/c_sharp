namespace SMS_Sender.Models;

public class MessageSendingResponse
{
    public bool Success { get; set; }
    public string ErrorMessage { get; set; }
    public string DateTime { get; set; }
}
