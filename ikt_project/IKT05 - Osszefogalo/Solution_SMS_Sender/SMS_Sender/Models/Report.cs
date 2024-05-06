namespace SMS_Sender.Models;

public class Report
{
    public List<MessageError> Errors { get; set; } = [];

    public int Success { get; set; }

    public DateTime Date { get; set; }
}
