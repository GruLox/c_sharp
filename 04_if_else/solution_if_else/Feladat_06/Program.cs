Console.Write("Please enter a number: ");
int x = int.Parse(Console.ReadLine());

Console.Write("Please enter a second number: ");
int y = int.Parse(Console.ReadLine());

Console.Write("Please enter a third number: ");
int z = int.Parse(Console.ReadLine());

if (x > y && x > z)
{
    if (y > z) {
        Console.WriteLine($"{x} > {y} > {z}");
    } else
    {
        Console.WriteLine($"{x} > {y} > {z}");
    }
} else if (y > x && y > z)
{
    if (x > z)
    {
        Console.WriteLine($"{y} > {x} > {z}");
    }
    else
    {
        Console.WriteLine($"{y} > {z} > {x}");
    }
} else
{
    if (y > x)
    {
        Console.WriteLine($"{z} > {y} > {x}");
    }
    else
    {
        Console.WriteLine($"{y} > {x} > {y}");
    }
}


