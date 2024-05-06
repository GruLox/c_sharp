namespace Project.Interfaces;

public interface IConsoleService
{
    T DisplayMenu<T>() where T : Enum;
}
