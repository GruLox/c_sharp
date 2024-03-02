int N = ExtendedConsole.ReadInteger("Kérem adja meg a mátrix nagyságát: ", int.MaxValue, 0);

double[,] matrix = MatrixService.GenerateSymmetricalMatrix(N);

double[] secondaryDiagonalElements = MatrixService.GetElementsOfSecondaryDiagonal<double>(matrix);

Console.WriteLine($"A mátrix mellékátlójának elemei: {string.Join(", ", secondaryDiagonalElements)}");


