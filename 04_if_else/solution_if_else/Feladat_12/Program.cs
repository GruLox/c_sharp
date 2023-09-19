Console.Write("Please enter a number: ");
int n = int.Parse(Console.ReadLine());

if (n >= 10 && n <= 20)
{
    Console.WriteLine($"{n} 10 és 20 között van");
} else if (n >= -20 && n <= -10)
{
    Console.WriteLine($"{n} -10 és -20 között van");
} else
{
    Console.WriteLine($"{n} nincs sem 10 és 20 között, sem -10 és -20 között");
}