Console.Write("Please enter a number: ");
int n = int.Parse(Console.ReadLine());

if (n % 4 == 0 && n % 6 == 0)
{
    Console.WriteLine($"{n} osztható 4-gyel és 6-tal is");

}
else
{
    Console.WriteLine($"{n} nem osztható 4-gyel és 6-tal is");
}