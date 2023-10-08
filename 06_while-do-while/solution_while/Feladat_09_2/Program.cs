int n = 0;

while (!(n >= 100 && n <= 999))
{
    Console.Write("Kérem adjon meg egy 3 jegyű számot: ");
    string input = Console.ReadLine();
    int.TryParse(input, out n);
}

Console.WriteLine($"{n} {(n % 7 == 0 ? "osztható" : "nem osztható")} 7-tel.");
