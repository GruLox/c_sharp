using _04_Interfaces.Shapes;

/// az interface egy szerződés amelyben szabályokat foglalunk össze
/// pl. lesz egy függvény amit minden osztály megvalósít


Shape shape = new Square(10);
PrintShape(shape);

shape = new Rectangle(5, 10);
PrintShape(shape);

// nem lehet, mivel a Circle nem implementálja az IShape interfacet
//IShape circle = new Circle(5);

static void PrintShape(IShape shape)
{
    if (shape is Square)
    {
        Console.WriteLine($"Square");
        Console.WriteLine(shape);
    }
    else if (shape is Rectangle)
    {
        Console.WriteLine($"Rectangle");
        Console.WriteLine(shape);
    }
    else if (shape is Circle)
    {
        Console.WriteLine($"Circle:");
    }
    else
    {
        Console.WriteLine("Unknown shape");
    }

}