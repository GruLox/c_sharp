namespace SMS_Sender.Services;

public class UserInterface(MessageManager messageManager) : IUserInterface
{
    private readonly MessageManager _messageManager = messageManager;

    public async Task Run()
    {
        while (true)
        {
            DisplayMainMenu();

            var option = ExtendedConsole.ReadEnum<UserOption>("Please select an option: ");

            switch (option)
            {
                case UserOption.AddNewMessage:
                    await AddMessage();
                    break;
                case UserOption.DeleteMessage:
                    await DeleteMessage();
                    break;
                case UserOption.SendMessages:
                    await SendMessages();
                    break;
                case UserOption.ViewReport:
                    await ViewReport();
                    break;
                case UserOption.Exit:
                    return;
            }
        }
    }

    public void DisplayMainMenu()
    {
        Console.Clear();

        Console.WriteLine("1 - Add new message");
        Console.WriteLine("2 - Delete message");
        Console.WriteLine("3 - Send messages");
        Console.WriteLine("4 - View report");
        Console.WriteLine("5 - Exit");
    }

    public async Task AddMessage()
    {
        var message = ReadNewMessageFromConsole();

        var date = ExtendedConsole.ReadDate("Enter the date: ", DateTime.Now.Date);

        try
        {
            await _messageManager.AddMessage(message, date);
            Console.WriteLine("Message added successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to add message: {ex.Message}");
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    public async Task DeleteMessage()
    {
        var mobileNumber = ExtendedConsole.ReadString("Enter the mobile number: ");
        var date = ExtendedConsole.ReadDate("Enter the date: ", DateTime.MinValue , DateTime.Now.Date);

        try
        {
            await _messageManager.DeleteMessage(mobileNumber, date);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to delete message: {ex.Message}");
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    public async Task SendMessages()
    {
        var today = DateTime.Now.Date;

        await _messageManager.SendMessages(today);

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    public async Task ViewReport()
    {
        var date = ExtendedConsole.ReadDate("Enter the date: ", DateTime.MinValue, DateTime.Now.Date);

        try
        {
            var report = await _messageManager.GetOrGenerateReport(date);
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
