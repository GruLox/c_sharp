public abstract class Pastry(double basePrice, double quantity) : IPrice
{
    protected double BasePrice { get; } = basePrice;
    protected double Quantity { get; set; } = quantity;

    public abstract void Taste();

    public double Cost()
    {
        return BasePrice * Quantity;
    }

    public override string ToString()
    {
        return $"{GetType().Name}: {Quantity} db, {Cost()} Ft";
    }
}
