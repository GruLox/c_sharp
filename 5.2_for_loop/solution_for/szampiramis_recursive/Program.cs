bool isNumber = false;
int size = 0;

size = GetSize();

BuildPyramid(size);

// Console.Clear
// ház rajzolás bónusz 5-ös


void BuildPyramid(int size, int n = 1)
{
    if (n - 1 == size) return;

    for (int i = 1; i <= n; i++)
    {
        Console.Write($"{i}\t");
    }

    // \n
    Console.WriteLine();

    BuildPyramid(size, n + 1);
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