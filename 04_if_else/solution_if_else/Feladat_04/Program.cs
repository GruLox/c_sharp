Console.Write("Please enter a number: ");
int x = int.Parse(Console.ReadLine());

Console.Write("Please enter another number: ");
int y = int.Parse(Console.ReadLine());

if (x > y)
{
    Console.WriteLine($"A nagyobbik szám: {x}");
} else if (y > x)
{
    Console.WriteLine($"A nagyobbik szám: {y}");
}
else
{
    Console.WriteLine("A két szám egyenlő");

}