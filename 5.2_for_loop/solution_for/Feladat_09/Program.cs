bool isNumber = false;
int intervallStart = 0;
int intervallEnd = 0;

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
} while (!isNumber || intervallStart <= intervallEnd);

if (intervallStart % 2 == 1) intervallStart--;
for (int i = intervallStart; i >= intervallEnd; i -= 2)
{
    Console.WriteLine(i);
}



