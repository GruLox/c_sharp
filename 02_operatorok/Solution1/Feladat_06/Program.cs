Console.Write("Please enter the first number: ");
double n1 = double.Parse(Console.ReadLine());

Console.Write("Please enter the second number: ");
double n2 = double.Parse(Console.ReadLine());

Console.Write("Please enter the third number: ");
double n3 = double.Parse(Console.ReadLine());


double eredmeny = (n1 + 0.5) * (n2 - 0.7) % n3;

Console.WriteLine($"Az eredmény: {eredmeny}");

Console.ReadKey();