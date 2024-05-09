namespace SMS_Sender.Services;

public class UserInterface(IMessageManager messageManager, IMenuService menuService) : IUserInterface
{
    private readonly IMessageManager _messageManager = messageManager;
    private readonly IMenuService _menuService = menuService;

    public async Task RunAsync()
    {
        while (true)
        {
            var option = _menuService.DisplayMenu<UserOption>();

            switch (option)
            {
                case UserOption.AddNewMessage:
                    await AddMessageAsync();
                    break;
                case UserOption.DeleteMessage:
                    await DeleteMessageAsync();
                    break;
                case UserOption.SendMessages:
                    await SendMessagesAsync();
                    break;
                case UserOption.ViewReport:
                    await ViewReportAsync();
                    break;
                case UserOption.Exit:
                    return;
            }
        }
    }

    private async Task AddMessageAsync()
    {
        var message = ReadNewMessageFromConsole();

        var date = ExtendedConsole.ReadDate("Enter the date: ", DateTime.Now.Date);

        try
        {
            await _messageManager.AddMessageAsync(message, date);
            Console.WriteLine("Message added successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to add message: {ex.Message}");
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private async Task DeleteMessageAsync()
    {
        var mobileNumber = ExtendedConsole.ReadString("Enter the mobile number: ");
        var date = ExtendedConsole.ReadDate("Enter the date: ", DateTime.MinValue , DateTime.Now.Date);

        try
        {
            await _messageManager.DeleteMessageAsync(mobileNumber, date);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to delete message: {ex.Message}");
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private async Task SendMessagesAsync()
    {
        var today = DateTime.Now.Date;

        await _messageManager.SendMessagesAsync(today);

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private async Task ViewReportAsync()
    {
        var date = ExtendedConsole.ReadDate("Enter the date: ", DateTime.MinValue, DateTime.Now.Date);

        try
        {
            var report = await _messageManager.GetOrGenerateReportAsync(date);
            Console.WriteLine($"Report for {date:yyyy-MM-dd}:");
            Console.WriteLine($"Success: {report.Success}");
            Console.WriteLine("Errors:");
            foreach (var error in report.Errors)
            {
                Console.WriteLine($"\tReason: {error.Reason}, Count: {error.Count}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to view report: {ex.Message}");
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private static Message ReadNewMessageFromConsole()
    {
        Console.Clear();

        var system = ExtendedConsole.ReadEnum<MobileOperatingSystem>("Enter the system: ");
        var firstName = ExtendedConsole.ReadString("Enter the first name: ");
        var lastName = ExtendedConsole.ReadString("Enter the last name: ");
        var mobileNumber = ExtendedConsole.ReadString("Enter the mobile number: ");
        var messageContent = ExtendedConsole.ReadString("Enter the message content: ");

        return new Message
        {
            System = system,
            FirstName = firstName,
            LastName = lastName,
            MobileNumber = mobileNumber,
            MessageContent = messageContent
        };
    }
}
