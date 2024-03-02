int ROW_COUNT = ExtendedConsole.ReadInteger("Kérem adja meg a sorok számát: ", int.MaxValue, 0);
int COL_COUNT = ExtendedConsole.ReadInteger("Kérem adja meg az oszlopok számát: ", int.MaxValue, 0);

int[,] matrix = new int[ROW_COUNT, COL_COUNT];
MatrixService.FillMatrixWithRandomNumbers(matrix, 0, 9);

MatrixService.PrintMatrix<int>(matrix);

int[,] transposedMatrix = MatrixService.TransposeMatrix<int>(matrix);
MatrixService.PrintMatrix<int>(transposedMatrix);




