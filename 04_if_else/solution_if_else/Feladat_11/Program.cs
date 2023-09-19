Console.Write("Please enter a number: ");
int n = int.Parse(Console.ReadLine());

bool isPositive = n > 0;
bool isEven = n % 2 == 0;
bool isDivisibleByFive = n % 5 == 0;

if (isPositive && isEven && isDivisibleByFive)
{
    Console.WriteLine($"{n} pozitív, páros és osztható 5-tel");
} 
else if (isPositive && isEven && !isDivisibleByFive)
{
    Console.WriteLine($"{n} pozitív, páros de nem osztahtó 5-tel");
} 
else if (isPositive && !isEven && !isDivisibleByFive)
{
    Console.WriteLine($"{n} pozitív, páratlan és nem osztható 5-tel");
} 
else if (isPositive && !isEven && isDivisibleByFive)
{
    Console.WriteLine($"{n} pozitív, páratlan és osztható 5-tel");
} 
else if (!isPositive && isEven && isDivisibleByFive)
{
    Console.WriteLine($"{n} negatív, páros és osztható 5-tel");
} 
else if (!isPositive && !isEven && isDivisibleByFive)
{
    Console.WriteLine($"{n} negatív, páratlan és osztható 5-tel");
} 
else if (!isPositive && isEven && !isDivisibleByFive)
{
    Console.WriteLine($"{n} negatív, páros és nem osztható 5-tel");
} 
else if (!isPositive && !isEven && !isDivisibleByFive)
{
    Console.WriteLine($"{n} negatív, páratlan és nem osztható 5-tel");
}