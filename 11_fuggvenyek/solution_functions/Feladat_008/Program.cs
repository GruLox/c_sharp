using IOLibrary;

const int BASE_TAX = 1000;

double width = ExtendedConsole.ReadDouble("Kérem adja meg a telek szélességét: ", int.MaxValue, 0);
double length = ExtendedConsole.ReadDouble("Kérem adja meg a telek hosszát: ", int.MaxValue, 0);

bool isTaxDeducted = DetermineTaxDeduction(width, length);

double taxAmount = CalculatePropertyTax(width, length, isTaxDeducted);

Console.WriteLine($"{taxAmount} Ft adót kell fizetni a telek után.");

static bool DetermineTaxDeduction(double width, double length) => width < 20 && length < 30;

static double CalculatePropertyTax(double width, double length, bool isTaxDeducted) =>
    isTaxDeducted ?
            width * length * BASE_TAX * 0.75 :
            width * length * BASE_TAX;