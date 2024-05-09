namespace Feladat_01;

public class Scone(double quantity) : Pastry(100, quantity)
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
