Console.Write("Please enter a number: ");
int x = int.Parse(Console.ReadLine());

Console.Write("Please enter another number: ");
int y = int.Parse(Console.ReadLine());

if (x > y)
{
    Console.WriteLine($"A nagyobbik szám: {x}, a kisebbik: {y}");
} else if (y > x)
{
    Console.WriteLine($"A nagyobbik szám: {y}, a kisebbik: {x}");
}
else
{
    Console.WriteLine($"{x} és {y} egyenlő.");

}