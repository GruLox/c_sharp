public class Scone(double quantity, double basePrice) : Pastry(basePrice, quantity)
{
    public override void Taste()
    {
        Console.WriteLine("Ez egy scone.");
        Quantity /= 2;
    }

    public override string ToString()
    {
        return base.ToString();
    }
}
