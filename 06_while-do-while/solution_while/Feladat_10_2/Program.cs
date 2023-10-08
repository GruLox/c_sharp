int n = int.MaxValue;
List<int> evenNumbers = new List<int>();
List<int> remainder3WhenDividedBy7 = new List<int>();
int sumOfDivisibleBy5 = 0;
int countOfDivisibleBy11 = 0;

while (n <= 0 || n > 99)
{
    Console.Write("Kérem adjon meg egy max 2 jegyű számot: ");
    string input = Console.ReadLine();
    int.TryParse(input, out n);
}

for (int i = 0; i < n + 1; i++)
{
    if (i % 2 == 0) evenNumbers.Add(i);
    if (i % 5 == 0) sumOfDivisibleBy5 += i;
    if (i % 11 == 0 && i != 0) countOfDivisibleBy11++;
    if (i % 7 == 3) remainder3WhenDividedBy7.Add(i);
}

Console.WriteLine($"Páros számok: {string.Join(", ", evenNumbers)}");
Console.WriteLine($"5-tel osztható számok összege: {sumOfDivisibleBy5}");
Console.WriteLine($"11-gyel osztható számok száma: {countOfDivisibleBy11}");
Console.WriteLine($"7-tel osztva 3 a maradék: {string.Join(", ", remainder3WhenDividedBy7)}");