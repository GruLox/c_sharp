bool isNumber;
int size;
int houseSquareWidth;
int tabCount;
string tabString;


do
{
    Console.Write("Kérem adja meg hány elemű a számpiramis: ");
    string input = Console.ReadLine();
    isNumber = int.TryParse(input, out size);
} while (!isNumber);

Console.Clear();

int numberCount = 1;
for (int i = 0; i < size; i++)
{
    tabCount = ((size * 2) - numberCount) / 2;
    tabString = new string('\t', tabCount);
    Console.Write(tabString);
    for (int j = 1; j <= numberCount; j++)
    {
        Console.Write($"{j}\t");
    }
    Console.Write(tabString);
    Console.WriteLine();
    numberCount += 2;
}

houseSquareWidth = (size - 2) * 2;

for (int i = 0; i < size * 2; i++)
{
    Console.Write("\t\t");
    for (int j = 1; j < houseSquareWidth; j++)
    {
        Console.Write($"{j}\t");
    }
    Console.WriteLine();
}

Console.ReadKey();