using IOLibrary;


double celsius = ExtendedConsole.ReadDouble("Kérem adja meg a hőmérsékletet Celsiusban");

char unit;
do
{
    Console.Write("Mibe szeretné átváltani (F, K): ");
    unit = Console.ReadKey().KeyChar;
    unit = char.ToUpper(unit);
    Console.WriteLine();
}
while (unit != 'F' && unit != 'K');


double convertedResult = unit == 'K' ? Math.CelsiusToKelvin(celsius) : Math.CelsiusToFahrenheit(celsius);

Console.WriteLine($"Az átváltott hőmérséklet: {convertedResult} {unit}");
