Console.WriteLine("1 - Coca Cola\n2 - Pepsi\n3 - Fanta\n4 - Sprite\nMake your order: ");
int orderIndex = int.Parse(Console.ReadLine());

string? orderedItem = orderIndex switch
{
    1 => "Coca Cola",
    2 => "Pepsi",
    3 => "Fanta",
    4 => "Sprite",
    _ => null,
};

Console.WriteLine($"The ordered item is {orderedItem ?? "not on the menu"}");
