namespace SMS_Sender.Interfaces;

public interface IMenuService
{
    T DisplayMenu<T>() where T : Enum;
}
