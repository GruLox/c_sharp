int N = ExtendedConsole.ReadInteger("Kérem adja meg a mátrix nagyságát: ", int.MaxValue, 0);

double[,] matrix = MatrixService.GenerateSymmetricalMatrix(N);

double maxValueUnderSecondaryDiagonal = MatrixService.GetMaxValueUnderSecondaryDiagonal<double>(matrix);

Console.WriteLine($"A mátrix mellékátlója alatti legnagyobb elem: {maxValueUnderSecondaryDiagonal}");





