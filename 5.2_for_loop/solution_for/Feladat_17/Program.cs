bool isNumber = false;
int intervallStart = 0;
int intervallEnd = 0;
List<int> numbers = new List<int>();

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
    numbers.Add(i);
}

double average = numbers.Average(x => x);

// double average = (intervallEnd + intervallStart) / 2

Console.WriteLine($"Az intervallumban található számok átlaga: {average}");



