using Custom.Library.ConsoleExtensions;

int N = ExtendedConsole.ReadInteger("Kérem adja meg a mátrix nagyságát: ", int.MaxValue, 0);

int[,] matrix = new int[N, N];
int indexMax = N - 1;

for (int i = 0; i < N; i++)
{
    for (int j = 0; j < N; j++)
    {
        matrix[i, j] = (i + 1) * (j + 1);
    }
}


int minValueAboveDiagonal = int.MaxValue;
for (int i = 0; i < N; i++)
{
    for (int j = 0; j < N; j++)
    {
        int indexSum = i + j;
        if (indexSum < indexMax)
        {
            minValueAboveDiagonal = matrix[i, j] < minValueAboveDiagonal ? matrix[i, j] : minValueAboveDiagonal;
        }
    }
}

Console.WriteLine($"A mátrix mellékátlója feletti legkisebb elem: {minValueAboveDiagonal}");





