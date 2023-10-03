using System.Globalization;

int number = 0;
bool isNumber = false;

while (!isNumber || number < 0 || number > 9)
{
    Console.Write("Adjon meg egy számot 0 és 9 között: ");
    string input = Console.ReadLine();

    isNumber = int.TryParse(input, new CultureInfo("en-US"), out number);

    if (!isNumber)
    {
        Console.WriteLine("Nem számot adott meg");
    }
    else if (number < 0 || number > 9)
    {
        Console.WriteLine("A megadott érték nincs a tartományban");
    }
}

Console.WriteLine($"A beolvasott szám: {number}");

Console.ReadKey();