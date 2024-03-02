int N = ExtendedConsole.ReadInteger("Kérem adja meg a mátrix nagyságát: ", int.MaxValue, 0);

double[,] matrix = MatrixService.GenerateSymmetricalMatrix(N);

double[][] elementsAboveMainDiagonal = new double[N-1][];
MatrixService.InitializeMatrixDescending<double>(elementsAboveMainDiagonal);

MatrixService.GetElementsAboveMainDiagonal<double>(matrix, elementsAboveMainDiagonal);

Console.WriteLine($"A mátrix főátlója feletti elemek:");
MatrixService.PrintMatrixElementsAboveDiagonal<double>(elementsAboveMainDiagonal);







