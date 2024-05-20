public class Condominium(int maxFlats, int maxGarages)
{
    private readonly List<RealEstate> _realEstates = [];
    private readonly int _maxFlats = maxFlats;
    private readonly int _maxGarages = maxGarages;
    private int FlatCount => _realEstates.Count(x => x is Flat);
    private int GarageCount => _realEstates.Count(x => x is Garage);

    public bool AddFlat(Flat flat)
    {
        if (FlatCount < _maxFlats)
        {
            _realEstates.Add(flat);
            return true;
        }
        return false;
    }

    public bool AddGarage(Garage garage)
    {
        if (GarageCount < _maxGarages)
        {
            _realEstates.Add(garage);
            return true;
        }
        return false;
    }

    public int TotalResidents()
    {
        return _realEstates.Where(x => x is Flat).Sum(x => (x as Flat)!.ResidentsCount());
    }

    public double TotalValue()
    {
        return _realEstates.Sum(x => x.TotalCost());
    }
}
