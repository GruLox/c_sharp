Random random = new Random();

int randomNumber = random.Next(0, 10);
Console.WriteLine(randomNumber);
int guess;
bool isNumber;
int tries = 5;

while (tries > 0)
{
    Console.Write("Próbálja meg kitalálni a random számot: ");
    string input = Console.ReadLine();
    isNumber = int.TryParse(input, out guess);
    if (isNumber && (guess >= 0 && guess <= 9))
    {
        if (guess == randomNumber)
        {
            break;
        }
        else
        {
            Console.WriteLine("Nem talált!");
            tries--;
        }
    }
    else if (isNumber)
    {
        Console.WriteLine("Nem 0 és 9 közötti számot adott meg");
    }
    else
    {
        Console.WriteLine("Nem számot adott meg");
    }

}

Console.WriteLine(tries == 0 ? "Vesztett" : "Győzött");