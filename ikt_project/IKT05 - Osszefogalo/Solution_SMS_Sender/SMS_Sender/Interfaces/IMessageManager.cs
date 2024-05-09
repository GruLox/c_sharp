namespace SMS_Sender.Interfaces;

public interface IMessageManager
{
    Task AddMessageAsync(Message message, DateTime date);

    Task DeleteMessageAsync(string mobileNumber, DateTime date);

    Task SendMessagesAsync(DateTime date);

    Task<Report> GetOrGenerateReportAsync(DateTime date);

}
