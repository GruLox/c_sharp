int N = ExtendedConsole.ReadInteger("Kérem adja meg a mátrix nagyságát: ", int.MaxValue, 0);

double[,] matrix = MatrixService.GenerateSymmetricalMatrix(N);

double sum = MatrixService.CalculateSumOfMainDiagonalElements<double>(matrix);

Console.WriteLine($"A mátrix fő átlójának összege: {sum}");


