using Custom.Library.ConsoleExtensions;

Car[] cars = GetCars(3);

Car[] carsAbove40Liters = cars.Where(c => c.FuelRefilled > 40).ToArray();
Console.WriteLine("40 liter felett tankolók:");
foreach (var car in carsAbove40Liters)
{
    Console.WriteLine(car);
}

int totalGasRefilled = cars.Sum(c => c.FuelRefilled);
Console.WriteLine($"Összesen {totalGasRefilled} liter benzint tankoltak");

Car[] carsWithMostGas = GetCarsWithMostGasRefilled(cars);
Console.WriteLine($"A legtöbbet tankolt autó(k): {string.Join<Car>(",", carsWithMostGas)}");

Car[] carsWithLeastGas = GetCarsWithLeastGasRefilled(cars);
Console.WriteLine($"A legkevesebbet tankolt autó: {string.Join<Car>(",", carsWithLeastGas)}");

int countOfCarsBelow30 = cars.Count(c => c.FuelRefilled < 30);
Console.WriteLine($"30 liter alatt tankolt autók száma: {countOfCarsBelow30}");

bool wasThereAnyCarThatRefilled50 = cars.Any(c => c.FuelRefilled == 50);
Console.WriteLine($"{(wasThereAnyCarThatRefilled50 ? "volt" : "nem volt")} olyan autó, amely 50 liter tankolt.");


static Car[] GetCars(int count)
{
    Car[] cars = new Car[count];
    for (int i = 0; i < count; i++)
    {

        string licensePlate = ExtendedConsole.ReadString("Rendszám: ");
        int fuelRefilled = ExtendedConsole.ReadInteger("Tankolt üzemanyag: ", int.MaxValue, 0);
        cars[i] = new Car(licensePlate, fuelRefilled);
    }
    return cars;
}

static Car[] GetCarsWithMostGasRefilled(Car[] cars)
{
    int maxGasRefilled = cars.Max(c => c.FuelRefilled);

    return cars.Where(c => c.FuelRefilled == maxGasRefilled).ToArray();
}

static Car[] GetCarsWithLeastGasRefilled(Car[] cars) 
{
    int leastGasRefilled = cars.Min(c => c.FuelRefilled);

    return cars.Where(c => c.FuelRefilled == leastGasRefilled).ToArray();
}