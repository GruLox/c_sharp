using Custom.Library.ConsoleExtensions;

int N = ExtendedConsole.ReadInteger("Kérem adja meg a mátrix nagyságát: ", int.MaxValue, 0);

int[,] matrix = new int[N, N];

for (int i = 0; i < N; i++)
{
    for (int j = 0; j < N; j++)
    {
        matrix[i, j] = (i + 1) * (j + 1);
    }
}

int[] diagonalElements = new int[N];
int maxIndex = N - 1;
for (int i = 0; i < N; i++)
{
    for (int j = 0; j < N; j++)
    {
        if (i + j == maxIndex)
        {
            diagonalElements[i] = matrix[i, j];
        }
    }
}

Console.WriteLine($"A mátrix mellékátlójának elemei: {string.Join(", ", diagonalElements)}");


