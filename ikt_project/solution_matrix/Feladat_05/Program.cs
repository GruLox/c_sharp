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

int maxIndex = N - 1;
int maxValueUnderDiagonal = 0;
for (int i = 0; i < N; i++)
{
    for (int j = 0; j < N; j++)
    {
        int indexSum = i + j;
        if (indexSum > maxIndex)
        {
            maxValueUnderDiagonal = matrix[i, j] > maxValueUnderDiagonal ? matrix[i, j] : maxValueUnderDiagonal;
        }
    }
}

Console.WriteLine($"A mátrix mellékátlója alatti legnagyobb elem: {maxValueUnderDiagonal}");





