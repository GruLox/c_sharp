int N = ExtendedConsole.ReadInteger("Kérem adja meg a mátrix nagyságát: ", int.MaxValue, 0);

double[,] matrix = MatrixService.GenerateSymmetricalMatrix(N);

double[][] elementsBelowMainDiagonal = new double[N - 1][];
MatrixService.InitializeMatrixAscending<double>(elementsBelowMainDiagonal);

MatrixService.GetElementsBelowMainDiagonal<double>(matrix, elementsBelowMainDiagonal);

Console.WriteLine($"A mátrix főátlója feletti elemek:");
MatrixService.PrintMatrixElementsBelowDiagonal<double>(elementsBelowMainDiagonal);







