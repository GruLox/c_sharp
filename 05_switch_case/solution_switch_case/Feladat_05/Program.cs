Console.Write("Enter the resistance of resistor1: ");
double resistor1 = int.Parse(Console.ReadLine());
Console.Write("Enter the resistance of resistor2: ");
double resistor2 = int.Parse(Console.ReadLine());

Console.Write("Enter the type of resistance bond");
string type = Console.ReadLine().ToLower();

double? resultantResistance = type switch
{
    "p" => (resistor1 + resistor2) / (resistor1 * resistor2),
    "s" => resistor1 + resistor2,
    _ => null,
};

if (resultantResistance is not null)
{
    Console.WriteLine($"The resultant resistance is: {resultantResistance}");
} 
else
{
    Console.WriteLine("Invalid type");
}