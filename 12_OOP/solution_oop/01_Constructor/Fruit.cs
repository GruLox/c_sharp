namespace _01_Constructor;

public class Fruit
{
    public string Name { get; set; }
    public int Calories { get; set; }
    public double Price { get; set; }

    public Fruit()
    {

    }

    public Fruit(string name, int calories, double price)
    {
        Name = name;
        Calories = calories;
        Price = price;
    }

    public Fruit(Fruit fruit) : this(fruit.Name, fruit.Calories, fruit.Price)
    {
    }


}
