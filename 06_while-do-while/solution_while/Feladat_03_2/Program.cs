Random random = new Random();

int randomNumber = random.Next(0, 10);
Console.WriteLine(randomNumber);
int guess = int.MaxValue;
bool isNumber;
int tries = 5;

while (tries > 0 && guess != randomNumber)
{
    Console.Write("Próbálja meg kitalálni a random számot: ");
    string input = Console.ReadLine();
    isNumber = int.TryParse(input, out guess);

    tries--;
    Console.WriteLine($"{tries} próbálkozása maradt");
}

Console.WriteLine(tries == 0 ? "Vesztett" : "Győzött");