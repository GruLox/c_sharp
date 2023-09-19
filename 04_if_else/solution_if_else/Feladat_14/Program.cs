Console.Write("Please enter a number: ");
int x = int.Parse(Console.ReadLine());

Console.Write("Please enter a second number: ");
int y = int.Parse(Console.ReadLine());

Console.Write("Please enter a third number: ");
int z = int.Parse(Console.ReadLine());

bool isDivisibleByZ = x % y == 0;
bool isDivisibleByY = x % z == 0;

if (isDivisibleByY && isDivisibleByZ)
{
    Console.WriteLine($"{x} osztható {y}-nal és {z}-vel is");
} else if (isDivisibleByY)
{
    Console.WriteLine($"{x} osztható {y}-nal de nem osztható {z}-vel");
} else if (isDivisibleByZ)
{
    Console.WriteLine($"{x} osztható {z}-nal de nem osztható {y}-vel");
} else
{
    Console.WriteLine($"{x} nem osztható sem {z}-nal, sem {y}-nal");
}