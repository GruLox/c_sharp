using Custom.Library.ConsoleExtensions;
using Feladat_10;

const int FRUIT_COUNT = 3;

Fruit[] fruits = GetFruits(FRUIT_COUNT);

int totalMass = fruits.Sum(f => f.Quantity);
Console.WriteLine($"Összesen {totalMass} kg gyümölcs van.");

Console.WriteLine("Készletértékek:");
foreach (var fruit in fruits)
{
    Console.WriteLine($"{fruit.Name} - {fruit.TotalValue} Ft");
}

int totalValueOfFruits = fruits.Sum(f => f.TotalValue);
Console.WriteLine($"Összesen {totalValueOfFruits} Ft értékű gyümölcs van.");

Fruit mostExpensiveFruit = fruits.OrderByDescending(f => f.Price).First();
Console.WriteLine($"A legdrágább gyümölcs: {mostExpensiveFruit}");

Fruit leastAvailableFruit = fruits.OrderBy(f => f.Quantity).First();
Console.WriteLine($"A legkevesebb gyümölcs: {leastAvailableFruit}");

Console.WriteLine("100 kg alattiak:");
Fruit[] fruitsBelow100 = fruits.Where(f => f.Quantity < 100).ToArray();
foreach (var fruit in fruitsBelow100)
{
    Console.WriteLine(fruit);
}

bool wasThereAnyFruitThatCostedMoreThan1500 = fruits.Any(f => f.Price > 1500);
Console.WriteLine($"{(wasThereAnyFruitThatCostedMoreThan1500 ? "volt" : "nem volt")} olyan gyümölcs, amely 1500 Ft-nál drágább.");

static Fruit[] GetFruits(int count)
{
    Fruit[] fruits = new Fruit[count];
    for (int i = 0; i < count; i++)
    {
        string name = ExtendedConsole.ReadString("Gyümölcs neve: ");
        int price = ExtendedConsole.ReadInteger("Gyümölcs ára: ", int.MaxValue, 0);
        int quantity = ExtendedConsole.ReadInteger("Gyümölcs mennyisége: ", int.MaxValue, 0);
        fruits[i] = new Fruit(name, price, quantity);
    }
    return fruits;

}