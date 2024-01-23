using Custom.Library.ConsoleExtensions;

int N = ExtendedConsole.ReadInteger("Kérem adja meg a mátrix nagyságát: ", int.MaxValue, 0);

int[,] matrix = new int[N, N];

for (int i = 0; i < N; i++)
{
    for (int j = 0; j < N; j++)
    {
        matrix[i, j] = (i+1) * (j+1);
    }
}

int sum = 0;
int diagonalIndex = 0;
for (int i = 0; i < N; i++)
{
    for (int j = 0; j < N; j++)
    {
        if (diagonalIndex == i && diagonalIndex == j)
        {
            sum += matrix[i, j];
            diagonalIndex++;
        }
    }
}

Console.WriteLine($"A mátrix fő átlójának összege: {sum}");


