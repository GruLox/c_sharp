public class RentedApartment(double area, int rooms, int residents, double pricePerSquareMeter) : Flat(area, rooms, residents, pricePerSquareMeter), Rentible
{
    private int _reservedMonths = 0;

    public double GetCost(int months)
    {
        if (residents == 0)
        {
            return -1;
        }
        return TotalCost() / residents * months;
    }

    public bool IsReserved()
    {
        return _reservedMonths != 0;
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

    public override bool MoveIn(int people)
    {
        if (people <= 8 && area / people >= 2)
        {
            residents = people;
            return true;
        }
        return false;
    }

    public override string ToString()
    {
        return base.ToString() + $", Reserved months: {_reservedMonths}";
    }
}
{
}
