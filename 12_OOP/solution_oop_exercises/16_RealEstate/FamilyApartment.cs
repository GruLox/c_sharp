public class FamilyApartment(double area, int rooms, int residents, double pricePerSquareMeter) : Flat(area, rooms, residents, pricePerSquareMeter)
{
    private int _childrenCount = 0;

    public bool ChildIsBorn()
    {
        if (residents >= 2)
        {
            residents++;
            _childrenCount++;
            return true;
        }
        return false;
    }

    public override bool MoveIn(int people)
    {
        if (people / rooms <= 2 && area / people >= 10)
        {
            residents = people;
            return true;
        }
        return false;
    }

    public override string ToString()
    {
        return base.ToString() + $", Children: {_childrenCount}";
    }
}

