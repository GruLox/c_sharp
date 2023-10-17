Random random = new Random();

int randomNumber = random.Next(0, 10);
Console.WriteLine(randomNumber);
int guess;
bool isNumber = false;
int tries = 5;

do
{
    Console.Write("Próbálja meg kitalálni a random számot: ");
    string input = Console.ReadLine();
    isNumber = int.TryParse(input, out guess);

    tries--;
    Console.WriteLine($"{tries} próbálkozása maradt");

} while (tries > 0 && guess != randomNumber || !isNumber);

Console.WriteLine(tries == 0 ? "Vesztett" : "Győzött");