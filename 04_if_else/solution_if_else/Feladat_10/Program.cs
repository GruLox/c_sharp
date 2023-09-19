Console.Write("Please enter a number: ");
int n = int.Parse(Console.ReadLine());

if (n % 2 == 0 && n % 3 == 0)
{
    Console.WriteLine($"ZIZI");
} else if (n % 2 == 0)
{
    Console.WriteLine($"BIZ");
} else if (n % 3 == 0)
{
    Console.WriteLine($"BAZ");
} else
{
    Console.WriteLine($"{n} nem osztható sem 2-vel sem 3-mal");
}
