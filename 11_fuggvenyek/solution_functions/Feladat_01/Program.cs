using IOLibrary;

Console.Write("Kérem adjon meg egy számot: ");
int n1 = ExtendedConsole.ReadInteger();
Console.Write("Kérem adjon meg egy másik számot: ");
int n2 = ExtendedConsole.ReadInteger();

Console.WriteLine($"A két szám összege: {Sum(n1, n2)}");
Console.WriteLine($"A két szám különbsége: {Subtract(n1, n2)}");
Console.WriteLine($"A két szám szorzata: {Multiply(n1, n2)}");
Console.WriteLine($"A két szám hányadosa: {Divide(n1, n2)}");


int Sum(int n1, int n2) => n1 + n2;

int Subtract(int n1, int n2) => n1 - n2;

double Multiply(double n1, double n2) => n1 * n2;

double Divide(double n1, double n2) => n1 / n2;