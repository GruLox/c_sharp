public class Scooter(string licensePlate, int speed, int maxSpeed) : Vehicle(speed, licensePlate), ISmallVehicle
{
    private int _maxSpeed = maxSpeed;

    public override bool IsSpeeding(int speedLimit)
    {
        return _speed > speedLimit;
    }

    public bool CanPassHere(int speedLimit)
    {
        return _maxSpeed <= speedLimit;
    }

    public override string ToString()
    {
        return $"Robogó: {base.ToString()}";
    }
}
