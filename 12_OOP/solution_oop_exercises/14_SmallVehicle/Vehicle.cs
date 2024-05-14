public abstract class Vehicle(int speed, string licensePlate)
{
    protected int _speed = speed;
    private string _licensePlate = licensePlate;

    public abstract bool IsSpeeding(int speedLimit);

    public override string ToString()
    {
        return $"{_licensePlate} - {_speed} km/h";
    }
}
