namespace SMS_Sender.Interfaces;

public interface IMessageManager
{
    Task AddMessage(Message message, DateTime date);

    Task DeleteMessage(string mobileNumber, DateTime date);

    Task SendMessages(DateTime date);

    Task<Report> GetOrGenerateReport(DateTime date);

}
