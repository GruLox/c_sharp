namespace Project.Services;

public static class ConsoleService
{
    #region Menu
    public static void PrintMenu()
    {
        Console.WriteLine("1. Add a new student");
        Console.WriteLine("2. Add a new subject to a student");
        Console.WriteLine("3. Add a new grade to a subject");
        Console.WriteLine("4. Modify existing data");
        Console.WriteLine("5. Exit");
    }

    public static void PrintMenuForModification()
    {
        Console.WriteLine("1. Modify student");
        Console.WriteLine("2. Modify subject");
        Console.WriteLine("3. Modify grade");
    }
    #endregion
}
