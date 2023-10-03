using System.Globalization;

int number = 0;
bool isNumber = false;


do
{
    Console.Write("Adjon meg egy számot 0 és 9 között: ");
    string input = Console.ReadLine();

    /*
        az input változó értékét (string) megpróbálja a TryParase számmá alakítani,
        -ha sikerül az isNumber értéke true lesz és a number változóban eltárolódik
        a beírt szám (string) szám értékként
        - ha nem sikerült az isNumber értéke false lesz
        - new CulatureInfo("en-US") jelentése az, hogy emrikai angol környezetben szeretnénk használni
        az átalakítást, azaz, ha tizedes számot (double, float) szeretnénk átalakítani (majd), 
        akkor a tizedes jelként megadott pontot a vessző helyett is tudja majd kezelni
     */

    isNumber = int.TryParse(input, new CultureInfo("en-US"), out number);

    if(!isNumber)
    {
        Console.WriteLine("Nem számot adott meg");
    }
    else if (number < 0 || number > 9)
    {
        Console.WriteLine("A megadott érték nincs a tartományban");
    }

}
while (!isNumber || number < 0 || number > 9);

Console.WriteLine($"A beolvasott szám: {number}");

Console.ReadKey();