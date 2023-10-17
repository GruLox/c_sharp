bool isNumber = false;
int intervallStart = 0;
int intervallEnd = 0;
int sum = 0;
int product = 1;

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
    sum += i;
    product *= i;
}

Console.WriteLine($"Az intervallumban található számok összege: {sum}");
Console.WriteLine($"Az intervallumban található számok szorzata: {product}");



