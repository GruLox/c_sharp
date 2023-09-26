Console.Write("Enter a number: ");
int x = int.Parse(Console.ReadLine());
Console.Write("Enter another number: ");
int y = int.Parse(Console.ReadLine());
Console.Write("Please enter a number: ");
string operatorInputted = Console.ReadLine();

double? result = operatorInputted switch
{
    "+" => x + y,
    "-" => x - y,
    "*" => x * y,
    "/" => (double)x / y,
    _ => null,
};

if (result is not null)
{
    Console.WriteLine($"The result is {result}");
} 
else
{
    Console.WriteLine($"Invalid operator");
}
