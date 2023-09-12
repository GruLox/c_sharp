Console.Write("Please type in the brand name: ");
string brand = Console.ReadLine();

Console.Write("Please type in the model: ");
string model = Console.ReadLine();

Console.Write("Please type in the type: ");
string type = Console.ReadLine();

Console.Write("Please type in the engine: ");
int kobcenti = int.Parse(Console.ReadLine());

Console.WriteLine($"Márka: {brand}\nModell: {model}\ntípus: {type}\n köbcenti: {kobcenti}");
