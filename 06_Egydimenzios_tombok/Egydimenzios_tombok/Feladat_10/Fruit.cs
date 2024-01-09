namespace Feladat_10;

public class Fruit
{
    public string Name { get; set; }

    public int Price { get; set; }

    public int Quantity { get; set; }

    public int TotalValue => Price * Quantity;

    public Fruit() { }

    public Fruit(string name, int price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }



    public override string ToString()
    {
        return $"{Name}, {Price} Ft, {Quantity} db.";
    }   
}
