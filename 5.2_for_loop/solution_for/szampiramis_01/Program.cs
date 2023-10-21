bool isNumber = false;
int size = 0;

do
{
    Console.Write("Kérem adja meg hány elemű a számpiramis: ");
    string input = Console.ReadLine();
    isNumber = int.TryParse(input, out size);
} while (!isNumber);

Console.Clear();

for (int i = 0; i <= size; i++)
{
    for (int j = 1; j <= i; j++)
    {
        Console.Write($"{j}\t");
    }
    Console.WriteLine();
}

Console.ReadKey();