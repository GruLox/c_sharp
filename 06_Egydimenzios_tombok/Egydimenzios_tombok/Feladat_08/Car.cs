namespace Feladat_07;

public class Car
{
    const int MAX_VELOCITY = 200;
    const int MIN_VELOCITY = 30;

    public string LicensePlate { get; set; }

    public int Velocity { get; set; }

    public int SpeedingFine => GetSpeedingFine(Velocity);



    public Car() { }

    public Car(string licensePlate, int velocity)
    {
        LicensePlate = licensePlate;
        Velocity = velocity;
    }

    public override string ToString()
    {
        return $"{LicensePlate} rendszámú autó {Velocity} km/h, büntetése: {SpeedingFine}";
    }

    private static int GetRandomVelocity()
    {
        Random rnd = new Random();
        return rnd.Next(MIN_VELOCITY, MAX_VELOCITY);
    }

    private static int GetSpeedingFine(int velocity)
    {
        return velocity switch
        {
            <= 90 => 0,
            <= 100 => 10000,
            <= 110 => 20000,
            _ => 30000
        };
    }
}
