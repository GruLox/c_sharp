bool isNumber = false;
int intervallStart = 0;
int intervallEnd = 0;
int evenSum = 0;
int oddSum = 0;

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
    if (i % 2 == 0) evenSum += i;
    else oddSum += i;
}

Console.WriteLine(evenSum);
Console.WriteLine(oddSum);
double average = (double)(evenSum + oddSum) / 2;

Console.WriteLine($"Az intervallumban a páros és páratlan számok összegének átlaga: {average}");



