using Custom.Library.ConsoleExtensions;
using Feladat_14;

Truck[] trucks = GetTrucks(3);

Console.WriteLine("Kamionok:");
PrintTrucksToConsole(trucks);

double totalWeight = trucks.Sum(t => t.Weight);
Console.WriteLine($"Összsúly: {totalWeight} kg");

double averageWeight = trucks.Average(t => t.Weight);
Console.WriteLine($"Átlagsúly: {averageWeight} kg");

Truck heaviestTruck = trucks.OrderByDescending(t => t.Weight).First();
Console.WriteLine($"Legnehezebb kamion: {heaviestTruck}");

bool wasThereAnyTruckWithWeigthOf10 = trucks.Any(t => t.Weight == 10);
Console.WriteLine($"{(wasThereAnyTruckWithWeigthOf10 ? "volt" : "nem volt")} 10 tonnás kamion.");

Truck[] trucksAboveTheWeigthOf10 = trucks.Where(t => t.Weight > 10).ToArray(); 
Console.WriteLine("10 tonnánál nehezebb kamionok:");
PrintTrucksToConsole(trucksAboveTheWeigthOf10);

Truck lightestTruck = trucks.OrderBy(t => t.Weight).First();
int indexOfLightestTruck = Array.IndexOf(trucks, lightestTruck);
Console.WriteLine($"{indexOfLightestTruck + 1}.-nek mérték a legkönnyebb kamiont.");



static Truck[] GetTrucks(int count)
{
    Truck[] trucks = new Truck[count];
    for (int i = 0; i < trucks.Length; i++)
    {
        string licensePlate = ExtendedConsole.ReadString("Rendszám: ");
        trucks[i] = new Truck(licensePlate);
    }
    return trucks;
}

static void PrintTrucksToConsole(Truck[] trucks)
{
    foreach (var truck in trucks)
    {
        Console.WriteLine(truck);
    }
}
