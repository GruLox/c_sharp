Console.Write("Enter the length of the rectangle: ");
double length = double.Parse(Console.ReadLine());

Console.Write("Enter the width of the rectangle: ");
double width = double.Parse(Console.ReadLine());

Console.WriteLine("t - terület\nk - kerület\na - átló");
Console.Write("Choose the operation: ");
string operationKey = Console.ReadLine().ToLower();

double? result = operationKey switch
{
    "t" => length * width,
    "k" => 2 * (length + width),
    "a" => Math.Sqrt(Math.Pow(length, 2) + Math.Pow(width, 2)),
    _ => null,
};

if (result is not null)
{
    Console.WriteLine($"The result is: {result}");
} 
else
{
    Console.WriteLine($"Invalid operation");
}