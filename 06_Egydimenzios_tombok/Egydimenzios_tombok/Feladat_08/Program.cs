using Custom.Library.ConsoleExtensions;
using Feladat_07;

const int CAR_COUNT = 2;

Car[] cars = GetCars(CAR_COUNT);

Car[] speedingCars = cars.Where(car => car.SpeedingFine > 0).ToArray();
Console.WriteLine("Gyorshajtók:");
foreach (var car in speedingCars)
{
    Console.WriteLine(car);

}

int sumOfFines = speedingCars.Sum(car => car.SpeedingFine);
Console.WriteLine($"Összes büntetés: {sumOfFines} Ft");


Car fastestCar = GetFastestCar(speedingCars);
Console.WriteLine($"A leggyorsabb autó: {fastestCar.LicensePlate} - {fastestCar.Velocity}");

int lawfulCommuterCount = CAR_COUNT - speedingCars.Length;
double lawfulCommuterRatio = ((double)lawfulCommuterCount / CAR_COUNT) * 100;
Console.WriteLine($"{lawfulCommuterCount} autó közlekedett szabályosan, ez az összes autó {lawfulCommuterRatio} százaléka");

bool wasVelocityOf60 = cars.Any(car => car.Velocity == 60);
Console.WriteLine($"{(wasVelocityOf60 ? "volt" : "nem volt")} 60 km/h-val közlekedő autó.");


static Car[] GetCars(int count)
{
    Car[] cars = new Car[count];
    for (int i = 0; i < count; i++)
    {
        string licensePlate = ExtendedConsole.ReadString($"Adja meg a {i + 1}. autó rendszámát: ");
        int velocity = ExtendedConsole.ReadInteger($"Adja meg a {i + 1}. autó sebességét: ", int.MaxValue, 0);

        cars[i] = new Car(licensePlate, velocity);
    }
    return cars;
}

static Car GetFastestCar(Car[] cars)
{
    int highestVelocity = cars.Max(car => car.Velocity);

    Car fastestCar = cars.First(car => car.Velocity == highestVelocity);

    return fastestCar;
}
