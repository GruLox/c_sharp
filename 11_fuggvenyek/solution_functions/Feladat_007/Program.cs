using IOLibrary;
using System.Reflection.Metadata.Ecma335;

double areaToPaint = ExtendedConsole.ReadDouble("Kérem adja meg a festendő felület nagyságát: ", int.MaxValue, 0);

int paintAmount = CalculatePaintAmount(areaToPaint);
Console.WriteLine($"{paintAmount} liter festékre van szükség, és {CalculatePaintCost(paintAmount)} forintba fog kerülni a festés");

static int CalculatePaintAmount(double areaToPaint) => (int)Math.Ceiling(areaToPaint * 0.15);
static double CalculatePaintCost(int paintAmount) => paintAmount * 930;