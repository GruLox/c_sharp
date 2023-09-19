Console.Write("Please enter a number: ");
int n = int.Parse(Console.ReadLine());

if (n >= 0 && n <= 9)
{
    Console.WriteLine($"{n} egyjegyű szám.");
} else if (n >= 10 && n <= 99) {
    Console.WriteLine($"{n} kétjegyű szám");
} else if (n >= 100 && n <= 999)
{
    Console.WriteLine($"{n} háromjegyű szám");
} else 
{
    Console.WriteLine($"{n} nem felelt meg egyik feltételnek sem");
}