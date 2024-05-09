namespace SMS_Sender.Services;

public class MessageManager(IMessageSenderFactory messageSenderFactory, IJsonUtilities jsonUtilities) : IMessageManager
{
    private const string DATA_DIRECTORY = "Data";
    private const string LOG_DIRECTORY = "Logs";
    private const string REPORT_DIRECTORY = "Reports";

    private static readonly string _projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory())!.Parent!.Parent!.FullName;
    private readonly IMessageSenderFactory _messageSenderFactory = messageSenderFactory;
    private readonly IJsonUtilities _jsonUtilities = jsonUtilities;

    public async Task AddMessageAsync(Message message, DateTime date)
    {
        if (date < DateTime.Now.Date)
        {
            throw new ArgumentException("Date cannot be earlier than the current date.");
        }

        var fileName = Path.Combine(_projectDirectory, DATA_DIRECTORY, $"messages_{date:yyyy-MM-dd}.json");
        var messages = new List<Message>();

        if (File.Exists(fileName))
        {
            messages = await _jsonUtilities.LoadDataFromJSON<Message>(fileName);
        }

        messages.Add(message);

        await _jsonUtilities.SaveDataToJSON(messages, fileName);
    }

    public async Task DeleteMessageAsync(string mobileNumber, DateTime date)
    {
        if (date > DateTime.Now.Date)
        {
            throw new ArgumentException("Date cannot be later than the current date.");
        }

        var fileName = Path.Combine(_projectDirectory, DATA_DIRECTORY, $"messages_{date:yyyy-MM-dd}.json");

        if (!File.Exists(fileName))
        {
            throw new FileNotFoundException("No messages found for the specified date.");
        }

        var messages = await _jsonUtilities.LoadDataFromJSON<Message>(fileName);

        var messageToDelete =
            messages.FirstOrDefault(m => m.MobileNumber == mobileNumber) ??
                throw new InvalidOperationException("No message found with the specified mobile number.");

        messages.Remove(messageToDelete);
        Console.WriteLine($"Message with mobile number {mobileNumber} deleted.");

        await _jsonUtilities.SaveDataToJSON(messages, fileName);
    }

    public async Task SendMessagesAsync(DateTime date)
    {
        var fileName = Path.Combine(_projectDirectory, DATA_DIRECTORY, $"messages_{date:yyyy-MM-dd}.json");

        if (!File.Exists(fileName))
        {
            Console.WriteLine("No messages found.");
            return;
        }

        var messages = await _jsonUtilities.LoadDataFromJSON<Message>(fileName);

        var notDeliveredLogFileName = Path.Combine(_projectDirectory, LOG_DIRECTORY, $"not_delivered_{date:yyyy-MM-dd}.json");
        var deliveredLogFileName = Path.Combine(_projectDirectory, LOG_DIRECTORY, $"delivered_{date:yyyy-MM-dd}.json");

        foreach (var message in messages)
        {
            var response = await SendSMSAsync(message);

            if (response.Success)
            {
                await SaveResponseToLogAsync(response, deliveredLogFileName);
                Console.WriteLine($"Message sent to {message.MobileNumber}.");
            }
            else
            {
                await SaveResponseToLogAsync(response, notDeliveredLogFileName);
                Console.WriteLine($"Message not sent to {message.MobileNumber}.");
            }
        }
    }

    public async Task<Report> GetOrGenerateReportAsync(DateTime date)
    {
        if (date > DateTime.Now.Date)
        {
            throw new ArgumentException("Date cannot be later than the current date.");
        }

        var fileName = Path.Combine(_projectDirectory, REPORT_DIRECTORY, $"report_{date:yyyy-MM-dd}.json");

        Report report;
        // If the report file does not exist, generate a new report
        if (!File.Exists(fileName))
        {
            report = await GenerateReportAsync(date);
        }
        else
        {
            // Otherwise, load the existing report
            report = (await _jsonUtilities.LoadDataFromJSON<Report>(fileName)).First();
        }

        return report;
    }

    private async Task<Report> GenerateReportAsync(DateTime date)
    {
        var notDeliveredLogFileName = Path.Combine(_projectDirectory, LOG_DIRECTORY, $"not_delivered_{date:yyyy-MM-dd}.json");
        var deliveredLogFileName = Path.Combine(_projectDirectory, LOG_DIRECTORY, $"delivered_{date:yyyy-MM-dd}.json");

        var notDeliveredLogs = new List<MessageSendingResponse>();
        var deliveredLogs = new List<MessageSendingResponse>();

        if (File.Exists(notDeliveredLogFileName))
        {
            notDeliveredLogs = await _jsonUtilities.LoadDataFromJSON<MessageSendingResponse>(notDeliveredLogFileName);
        }

        if (File.Exists(deliveredLogFileName))
        {
            deliveredLogs = await _jsonUtilities.LoadDataFromJSON<MessageSendingResponse>(deliveredLogFileName);
        }

        var report = new Report
        {
            Success = deliveredLogs.Count,
            Errors = notDeliveredLogs.GroupBy(l => l.ErrorMessage)
                .Select(g => new MessageError { Reason = g.Key, Count = g.Count() })
                .ToList(),
            Date = date
        };

        var fileName = Path.Combine(_projectDirectory, REPORT_DIRECTORY, $"report_{date:yyyy-MM-dd}.json");

        await _jsonUtilities.SaveDataToJSON(new List<Report> { report }, fileName);

        return report;
    }

    private async Task<MessageSendingResponse> SendSMSAsync(Message message)
    {
        var messageSender = _messageSenderFactory.GetMessageSender(message.System);

        return await messageSender.SendMessageAsync(message);
    }

    private async Task SaveResponseToLogAsync(MessageSendingResponse response, string logFileName)
    {
        var logs = new List<MessageSendingResponse>();

        if (File.Exists(logFileName))
        {
            logs = await _jsonUtilities.LoadDataFromJSON<MessageSendingResponse>(logFileName);
        }

        logs.Add(response);

        await _jsonUtilities.SaveDataToJSON(logs, logFileName);
    }
}