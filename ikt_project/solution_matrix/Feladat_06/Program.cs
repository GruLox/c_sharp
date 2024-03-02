int N = ExtendedConsole.ReadInteger("Kérem adja meg a mátrix nagyságát: ", int.MaxValue, 0);

double[,] matrix = MatrixService.GenerateSymmetricalMatrix(N);

double minValueUnderSecondaryDiagonal = MatrixService.GetMinValueAboveSecondaryDiagonal<double>(matrix);

Console.WriteLine($"A mátrix mellékátlója feletti legkisebb elem: {minValueUnderSecondaryDiagonal}");





