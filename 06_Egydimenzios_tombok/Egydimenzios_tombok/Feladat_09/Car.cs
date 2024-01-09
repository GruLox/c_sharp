
public class Car
{

    public string LicensePlate { get; set; }

    public int FuelRefilled { get; set; }



    public Car() { }

    public Car(string licensePlate, int fuelRefilled)
    {
        LicensePlate = licensePlate;
        FuelRefilled = fuelRefilled;
    }

    public override string ToString()
    {
        return $"{LicensePlate} rendszámú autó, {FuelRefilled} liter.";
    }
}
