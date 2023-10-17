bool isNumber = false;
int intervallStart = 0;
int intervallEnd = 0;
int sumOfDivisibleBy5 = 0;
int sumOfDivisibleBy7 = 0;


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
    if (i % 5 == 0) sumOfDivisibleBy5 += i;
    if (i % 7 == 0) sumOfDivisibleBy7 += i;
}

string biggerNumber = sumOfDivisibleBy5 > sumOfDivisibleBy7 ? "5-tel osztható" : "7-tel osztható";

Console.WriteLine($"Az intervallumban a {biggerNumber} számok összege a nagyobb");



