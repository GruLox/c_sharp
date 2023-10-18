bool isNumber = false;
int size = 0;

size = GetSize();

BuildPyramid(1, size);


void BuildPyramid(int n, int size)
{
    if (n - 1 == size) return;

    for (int i = 1; i <= n; i++)
    {
        Console.Write($"{i}\t");
    }
    Console.WriteLine();

    BuildPyramid(n + 1, size);
}

int GetSize()
{
    int size = 0;
    do
    {
        Console.Write("Kérem adja meg hány elemű a számpiramis: ");
        string input = Console.ReadLine();
        isNumber = int.TryParse(input, out size);
    } while (!isNumber);

    return size;
}