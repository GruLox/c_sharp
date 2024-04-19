namespace Project.Services;

public static class ConsoleService
{
    #region Menu
    public static void DisplayMainMenu()
    {
        Console.Clear();

        Console.WriteLine("1. View all students");
        Console.WriteLine("2. Add");
        Console.WriteLine("3. Modify existing data");
        Console.WriteLine("4. Exit");
    }

    public static void DisplayAddMenu()
    {
        Console.Clear();

        Console.WriteLine("1. Add student");
        Console.WriteLine("2. Add subject to student");
        Console.WriteLine("3. Add grade to subject of student");
    }

    public static void DisplayModificationMenu()
    {
        Console.Clear();

        Console.WriteLine("1. Modify student");
        Console.WriteLine("2. Modify subject");
        Console.WriteLine("3. Modify grade");
    }
    #endregion
}
