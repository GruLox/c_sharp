Console.Write("Kérem adja meg a nevét: ");
string name = Console.ReadLine();

Console.Write("Kérem adja meg a születési évét: ");
int birthYear = int.Parse(Console.ReadLine());

Console.WriteLine($"{name} ön {birthYear}-ben született");