Console.Write("Please enter a number: ");
int x = int.Parse(Console.ReadLine());

Console.Write("Please enter another number: ");
int y = int.Parse(Console.ReadLine());

if (x % y == 0)
{
    Console.WriteLine($"{y} osztója {x}-nek");
} else
{
    Console.WriteLine($"{y} nem osztója {x}-nek");

}