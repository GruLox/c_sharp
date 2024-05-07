namespace SMS_Sender.Services;

public class MenuService : IMenuService
{
    /// <summary>
    /// Displays a menu for an enum type and returns the selected option.
    /// The user can navigate through the options using the up and down arrow keys, and select an option by pressing enter.
    /// </summary>
    /// <typeparam name="T">The type of the enum.</typeparam>
    /// <returns>The selected option.</returns>
    public T DisplayMenu<T>() where T : Enum
    {
        // Get all the descriptions of the enum values, the descriptions are used as the options
        var options = Enum.GetValues(typeof(T)).Cast<T>().Select(e => GetDescription(e)).ToArray();
        int currentSelection = 0;

        ConsoleKeyInfo keyInfo;

        do
        {
            Console.Clear();

            for (int i = 0; i < options.Length; i++)
            {
                if (i == currentSelection)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                Console.WriteLine($"{i + 1}. {options[i]}");

                Console.ResetColor();
            }

            keyInfo = Console.ReadKey();

            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                if (currentSelection > 0) currentSelection--;
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                if (currentSelection < options.Length - 1) currentSelection++;
            }

        } while (keyInfo.Key != ConsoleKey.Enter);

        return (T)Enum.GetValues(typeof(T)).GetValue(currentSelection)!;
    }

    /// <summary>
    /// Gets the description of an enum value.
    /// If a description is not provided, it returns the name of the enum value.
    /// </summary>
    /// <typeparam name="T">The type of the enum.</typeparam>
    /// <param name="enumValue">The enum value.</param>
    /// <returns>The description of the enum value.</returns>
    private static string GetDescription<T>(T enumValue) where T : Enum
    {
        var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
        var attributes = (DescriptionAttribute[])fieldInfo!.GetCustomAttributes(typeof(DescriptionAttribute), false);

        return attributes.Length > 0 ? attributes[0].Description : enumValue.ToString();
    }
}
