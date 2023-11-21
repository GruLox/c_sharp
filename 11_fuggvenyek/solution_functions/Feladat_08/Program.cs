using CustomLibrary;

Point a = GetPoint();
Point b = GetPoint();


double y = Math.Abs(a.Y - b.Y);
double x = Math.Abs(a.X - b.X);

double distance = MathFunctions.PythegoreanTheorem(x, y);
Console.WriteLine($"A távolság: {distance}");
Point GetPoint()
{
    int x = ExtendedConsole.ReadInteger("Adja meg a koordináta x értékét: ");
    int y = ExtendedConsole.ReadInteger("Adja meg a koordináta y értékét: ");

    return new Point(x, y);
}






