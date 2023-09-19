Console.Write("Please enter a number: ");
int n = int.Parse(Console.ReadLine());

if (n % 5 == 0)
{
    Console.WriteLine($"{n} osztható 5-tel");

} else
{
    Console.WriteLine($"{n} nem osztható 5-tel");
}