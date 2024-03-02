namespace Custom.Library.MatrixHelpers;

public static class MatrixService
{
    private static Random random = new Random();
    public static double[,] GenerateSymmetricalMatrix(int n)
    {
        double[,] matrix = new double[n, n];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = double.Parse($"{i}.{j}");
            }
        }

        return matrix;
    }

    public static double CalculateSumOfMainDiagonalElements<T>(T[,] matrix) 
    {
        if (typeof(T) != typeof(int) && typeof(T) != typeof(double))
        {
            throw new ArgumentException("Matrix must be of type int or double.");
        }

        int N = matrix.GetLength(0);
        double sum = 0;

        for (int i = 0; i < N; i++)
        {
            sum += Convert.ToDouble(matrix[i, i]);
        }

        return sum;
    }

    public static T[] GetElementsOfSecondaryDiagonal<T>(T[,] matrix)
    {
        int N = matrix.GetLength(0);
        T[] diagonalElements = new T[N];
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

        return diagonalElements;
    }

    public static void InitializeMatrixDescending<T>(T[][] matrix)
    {
        int N = matrix.Length;
        for (int i = 0; i < N; i++)
        {
            matrix[i] = new T[N - i];
        }
    }

    public static void InitializeMatrixAscending<T>(T[][] matrix)
    {
        int N = matrix.Length;
        for (int i = 0; i < N; i++)
        {
            matrix[i] = new T[i + 1];
        }
    }

    public static void GetElementsAboveMainDiagonal<T>(T[,] matrix, T[][] elementsAboveMainDiagonal)
    {
        int N = matrix.GetLength(0);
        int resultIndex = 0;
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (i - j < 0)
                {
                    elementsAboveMainDiagonal[i][resultIndex] = matrix[i, j];
                    resultIndex++;
                }
            }
            resultIndex = 0;
        }
    }

    public static void GetElementsBelowMainDiagonal<T>(T[,] matrix, T[][] elementsBelowMainDiagonal)
    {
        int N = matrix.GetLength(0);
        int resultIndex = 0;
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (i - j > 0)
                {
                    elementsBelowMainDiagonal[i - 1][resultIndex] = matrix[i, j];
                    resultIndex++;
                }
            }
            resultIndex = 0;
        }
    }

    public static T GetMaxValueUnderSecondaryDiagonal<T>(T[,] matrix)
    {
        if (typeof(T) != typeof(int) && typeof(T) != typeof(double))
        {
            throw new ArgumentException("Matrix must be of type int or double.");
        }

        int N = matrix.GetLength(0);
        int maxIndex = N - 1;
        T maxValueUnderDiagonal = default!;
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                int indexSum = i + j;
                if (indexSum > maxIndex)
                {
                    maxValueUnderDiagonal = matrix[i, j];
                }
            }
        }
        return maxValueUnderDiagonal!;
    }

    public static double GetMinValueAboveSecondaryDiagonal<T>(T[,] matrix)
    {
        if (typeof(T) != typeof(int) && typeof(T) != typeof(double))
        {
            throw new ArgumentException("Matrix must be of type int or double.");
        }

        int N = matrix.GetLength(0);
        double minValueAboveDiagonal = double.MaxValue;
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                int indexSum = i + j;
                if (indexSum < N - 1)
                {
                    minValueAboveDiagonal = Convert.ToDouble(matrix[i, j]) < minValueAboveDiagonal
                        ? Convert.ToDouble(matrix[i, j]) :
                        minValueAboveDiagonal;
                }
            }
        }
        return minValueAboveDiagonal;
    }

    public static void FillMatrixWithRandomNumbers(double[,] matrix, double min, double max, int decimals = 2)
    {
        int rowCount = matrix.GetLength(0);
        int columnCount = matrix.GetLength(1);
        for (int i = 0; i < rowCount; i++)
        {
            for (int j = 0; j < columnCount; j++)
            {
                matrix[i, j] = Math.Round(random.NextDouble() * (max - min) + min, decimals);
            }
        }
    }

    public static void FillMatrixWithRandomNumbers(int[,] matrix, int min, int max)
    {
        int rowCount = matrix.GetLength(0);
        int columnCount = matrix.GetLength(1);
        for (int i = 0; i < rowCount; i++)
        {
            for (int j = 0; j < columnCount; j++)
            {
                matrix[i, j] = random.Next(min, max + 1);
            }
        }
    }

    public static double[] GetRowAverages<T>(T[,] matrix)
    {
        if (typeof(T) != typeof(int) && typeof(T) != typeof(double))
        {
            throw new ArgumentException("Matrix must be of type int or double.");
        }

        int rowLength = matrix.GetLength(0);
        int columnLength = matrix.GetLength(1);
        double[] averages = new double[rowLength];

        for (int i = 0; i < rowLength; i++)
        {
            double total = 0;
            for (int j = 0; j < columnLength; j++)
            {
                total += Convert.ToDouble(matrix[i, j]);
            }
            averages[i] = total / columnLength;
        }

        return averages;
    }

    public static T[] GetElementsFromColumn<T>(T[,] matrix, int columnIndex)
    {
        int rowCount = matrix.GetLength(0);
        T[] columnElements = new T[rowCount];
        for (int i = 0; i < rowCount; i++)
        {
            columnElements[i] = matrix[i, columnIndex];
        }
        return columnElements;
    }

    public static T[,] TransposeMatrix<T>(T[,] matrix)
    {
        int rowLength = matrix.GetLength(0);
        int columnLength = matrix.GetLength(1);
        T[,] transposedMatrix = new T[columnLength, rowLength];

        for (int i = 0; i < columnLength; i++)
        {
            T[] columnElements = GetElementsFromColumn(matrix, i);
            for (int j = 0; j < rowLength; j++)
            {
                transposedMatrix[i, j] = columnElements[j];
            }
        }
        return transposedMatrix;
    }

    public static void PrintMatrix<T>(T[,] matrix)
    {
        int rowLength = matrix.GetLength(0);
        int columnLength = matrix.GetLength(1);

        for (int i = 0; i < rowLength; i++)
        {
            for (int j = 0; j < columnLength; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    public static void PrintMatrixElementsAboveDiagonal<T>(T[][] matrix)
    {
        for (int i = 0; i < matrix.Length; i++)
        {
            Console.WriteLine($"{new string(' ', i * 4)}{string.Join(' ', matrix[i])}");
        }
    }

    public static void PrintMatrixElementsBelowDiagonal<T>(T[][] matrixElements)
    {
        for (int i = 0; i < matrixElements.Length; i++)
        {
            Console.WriteLine($"{string.Join(' ', matrixElements[i])}");
        }
    }
}
