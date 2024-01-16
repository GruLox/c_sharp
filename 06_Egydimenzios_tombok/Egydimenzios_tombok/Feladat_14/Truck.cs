namespace Feladat_14;


public class Truck
{
    const double MAX_WEIGHT = 40.0;
    const double MIN_WEIGHT = 3.5;

    public string LicensePlate { get; set; }

    public double Weight { get; }

    public Truck(string licensePlate)
    {
        LicensePlate = licensePlate;
        Weight = GetRandomWeight(MIN_WEIGHT, MAX_WEIGHT);
    }

    private double GetRandomWeight(double min, double max)
    {
        Random random = new Random();
        return Math.Round(random.NextDouble() * (max - min) + min, 2);
    }

    public override string ToString()
    {
        return $"{LicensePlate} - {Weight} kg";
    }


}
