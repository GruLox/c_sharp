
//– Bovítsd ki az örökölt ToString metódust, hogy az alábbiakat adja vissza: "Audi:
//rendszám - X km/h"(ahol rendszám a jármu rendszáma, X pedig az akutális sebessége).
//Használd fel az ősosztály ToString metódusát is!
public class AudiS8(string licensePlate, int speed, bool hasLaserBlocker) : Vehicle(speed, licensePlate)
{
    private bool _hasLaserBlocker = hasLaserBlocker;

    public override bool IsSpeeding(int speedLimit)
    {
        if (_hasLaserBlocker)
        {
            return false;
        }
        return _speed > speedLimit;
    }

    public override string ToString()
    {
        return $"Audi: {base.ToString()}";
    }
}
