public class Garage(double area, double pricePerSquareMeter, bool isHeated) : RealEstate, Rentible
{
    private readonly double _area = area;
    private readonly double _pricePerSquareMeter = pricePerSquareMeter;
    private readonly bool _isHeated = isHeated;
    private int _reservedMonths = 0;
    private bool _hasCar = false;

    public double TotalCost()
    {
        return _area * _pricePerSquareMeter;
    }

    public double GetCost(int months)
    {
        double cost = _area * _pricePerSquareMeter * 1.5;
        if (_isHeated)
        {
            cost *= 1.5;
        }
        return cost * months;
    }

    public bool IsReserved()
    {
        return _reservedMonths > 0 || _hasCar;
    }

    public bool Reserve(int months)
    {
        if (_reservedMonths == 0)
        {
            _reservedMonths = months;
            return true;
        }
        return false;
    }

    public void AutoKiBeAll()
    {
        _hasCar = !_hasCar;
    }

    public override string ToString()
    {
        return $"Area: {_area}, Price per square meter: {_pricePerSquareMeter}, Heated: {_isHeated}, Reserved months: {_reservedMonths}, Has car: {_hasCar}";
    }
}
