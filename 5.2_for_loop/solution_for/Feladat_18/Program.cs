bool isNumber = false;
int intervallStart = 0;
int intervallEnd = 0;
int result = 0;

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

int signChanger = 1;
for (int i = 0, number = intervallStart; i <= intervallEnd - intervallStart; i++, number++)
{
    result += signChanger * i;
    signChanger *= -1;
}

Console.WriteLine($"Az eredmény: {result}");



