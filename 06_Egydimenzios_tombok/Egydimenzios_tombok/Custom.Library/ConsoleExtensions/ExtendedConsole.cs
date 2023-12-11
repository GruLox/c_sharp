namespace Custom.Library.ConsoleExtensions;

public static class ExtendedConsole
{
    public static int ReadInteger(string prompt, int min, int max)
    {
        bool isNumber = false;
        int number = 0;

        do
        {
            Console.Write(prompt);

            string text = Console.ReadLine()!;
            isNumber = int.TryParse(text, out number);
        }
        while (!isNumber || number < min || number > max);

        return number;
    }

    public static double ReadDouble(string prompt, int min, int max)
    {
        bool isNumber = false;
        double number = 0;

        do
        {
            Console.Write(prompt);

            string text = Console.ReadLine()!;
            isNumber = double.TryParse(text, new CultureInfo("en-EN"), out number);
        }
        while (!isNumber || number > max || number < min);

        return number;
    }

    public static string ReadString(string prompt)
    {
        string text = string.Empty;

        do
        {
            Console.Write(prompt);

            text = Console.ReadLine()!.Trim();
        }
        while (string.IsNullOrWhiteSpace(text));

        return text;
    }

    public static int ReadBirthYear(int max, string prompt)
    {
        bool isNumber = false;
        int number = 0;

        do
        {
            Console.Write(prompt);

            string text = Console.ReadLine()!;
            isNumber = int.TryParse(text, out number);

            if (number > max)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine($"A megadott szám nem lehet nagyobb mint {max}");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("A folytatáshoz nyomjon meg egy gombot!");

                Console.ReadKey();
                Console.Clear();

                Console.ResetColor();
            }

        }
        while (!isNumber || number > max);

        return number;
    }

    public static char ReadChar(string prompt)
    {
        string text = string.Empty;
        char letter = '\0';

        do
        {
            Console.Write(prompt);

            text = Console.ReadLine()!.Trim().ToLower();
            letter = char.Parse(text);
        }
        while (string.IsNullOrWhiteSpace(text));

        return letter;
    }

    public static int GetRandom(int number1, int number2)
    {
        Random rnd = new Random();
        int rndNumber = rnd.Next(number1, number2);

        return rndNumber;
    }

}

