using System.Globalization;

Console.Write("Please type in your name: ");
string name = Console.ReadLine();
Console.Write("Please type in your height: ");
double height = double.Parse(Console.ReadLine(), new CultureInfo("en-EN"));

Console.WriteLine($"{name} az ön magassága {height}");