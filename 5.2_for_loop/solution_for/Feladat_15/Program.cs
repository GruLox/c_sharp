bool isNumber = false;
int intervallStart = 0;
int intervallEnd = 0;
int countOfOddsDivisibleBy3 = 0;

do
{
    Console.Write("Adjon meg egy kezdőértéket: ");
    string input = Console.ReadLine();
    isNumber = int.TryParse(input, out intervallStart);
} while (!isNumber);

isNumber = false;
do
{
    Console.Write("Adjon meg egy végértéket: ");
    string input = Console.ReadLine();
    isNumber = int.TryParse(input, out intervallEnd);
} while (!isNumber || intervallStart >= intervallEnd);

for (int i = intervallStart; i <= intervallEnd; i++)
{
    if (i % 3 == 0 && i % 2 == 1) countOfOddsDivisibleBy3++;
}

Console.WriteLine($"Az intervallumban a a 3-mal osztható páratlan számok száma: {countOfOddsDivisibleBy3}");



