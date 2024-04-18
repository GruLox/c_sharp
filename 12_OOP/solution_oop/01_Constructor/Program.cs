using _01_Constructor;

// parameterless constructor
var apple = new Fruit();
apple.Name = "Apple";
apple.Calories = 60;
apple.Price = 450;
apple.Importers.Add("ABCS");
//apple.Importers = new List<string> { "ABCS", "XYZ" }; // private set
//apple.HasImporters = true; // read-only property

// object initializer
var orange = new Fruit
{
    Name = "Orange",
    Calories = 90,
    Price = 380
};

// constructor with parameters
var banana = new Fruit("Banana", 89, 600);

// copy constructor
var gala = new Fruit(apple);