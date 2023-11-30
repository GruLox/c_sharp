using IOLibrary;

Random random = new Random();

int firstRand = random.Next(0, 10);
int secondRand = random.Next(40, 51);

int solution = random.Next(firstRand, secondRand+1);
Console.WriteLine(solution);

int tries = GuessingGame(solution);

Console.WriteLine($"Ön eltalálta a számot {tries} próbálkozás után.");

int GuessingGame(int solution)
{
    int guess = 0;
    int tries = 0;
    while (guess != solution)
    {
        guess = ExtendedConsole.ReadInteger("Kérem találja ki a számot: ", 50, 0);
        if (guess > solution)
        {
            Console.WriteLine("A megoldás kisebb mint a megadott szám");
        }
        else if (guess < solution)
        {
            Console.WriteLine("A megoldás nagyobb mint a megadott szám.");
        }
        tries++;
    }
    return tries;
}