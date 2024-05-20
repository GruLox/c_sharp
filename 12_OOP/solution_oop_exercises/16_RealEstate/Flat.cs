public abstract class Flat(double area, int rooms, int residents, double pricePerSquareMeter) : RealEstate
{
    protected double area = area;
    protected int rooms = rooms;
    protected int residents = residents;
    protected double pricePerSquareMeter = pricePerSquareMeter;

    public abstract bool MoveIn(int people);

    public double TotalCost()
    {
        return area * pricePerSquareMeter;
    }

    public int ResidentsCount()
    {
        return residents;
    }

    public override string ToString()
    {
        return $"Area: {area}, Rooms: {rooms}, Residents: {residents}, Price per square meter: {pricePerSquareMeter}";
    }
}
