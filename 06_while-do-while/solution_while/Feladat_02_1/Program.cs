string name = string.Empty;

while (name.Length < 2)
{
    Console.Write("Kérem adja meg a nevét: ");
    name = Console.ReadLine();
}

Console.WriteLine($"Üdvözlöm, {name}");