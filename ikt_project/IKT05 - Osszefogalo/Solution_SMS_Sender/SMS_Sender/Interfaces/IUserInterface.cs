namespace SMS_Sender.Interfaces;

public interface IUserInterface
{
    Task Run();

    void DisplayMainMenu();

    Task AddMessage();

    Task DeleteMessage();

    Task SendMessages();

    Task ViewReport();
}
