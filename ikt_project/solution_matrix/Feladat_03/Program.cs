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

int[][] elementsAboveTheDiagonal = new int[N-1][];
for (int i = 0; i < elementsAboveTheDiagonal.Length; i++)
{
    elementsAboveTheDiagonal[i] = new int[indexMax - i];
}

int resultIndex = 0;
for (int i = 0; i < N; i++)
{
    for (int j = 0; j < N; j++)
    {
        if (i - j < 0)
        {
            elementsAboveTheDiagonal[i][resultIndex] = matrix[i, j];
            resultIndex++;
        }
    }
    resultIndex = 0;
}

Console.WriteLine($"A mátrix főátlója feletti elemek:");
PrintMatrixElements(elementsAboveTheDiagonal);


static void PrintMatrixElements(IEnumerable<int>[] matrixElements)
{
    for (int i = 0; i <  matrixElements.Length; i++)
    {
        Console.WriteLine($"{new string(' ', i*2)}{string.Join(' ', matrixElements[i])}");
    }
}





