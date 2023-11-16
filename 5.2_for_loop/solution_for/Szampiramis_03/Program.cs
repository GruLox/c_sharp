bool isNumber;
int size;
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
    tabString = new String('\t', tabCount);
    Console.Write(tabString);
    for (int j = 1; j <= numberCount; j++)
    {
        Console.Write($"{j}\t");
    }
    Console.Write(tabString);
    Console.WriteLine();
    numberCount += 2;
}

Console.ReadKey();