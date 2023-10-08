int beverageIndex = 0;

while (!Enumerable.Range(1, 3).Contains(beverageIndex)) {
    Console.Write("1 - Sprite\n2 - Coca-Cola\n3 - Fanta\nKérem válasszon üdítőt: ");
    string input = Console.ReadLine();
    int.TryParse(input, out beverageIndex);
}

string beverage = beverageIndex switch
{
    1 => "Sprite",
    2 => "Coca-Cola",
    3 => "Fanta"
};

Console.WriteLine($"A választott üdítő: {beverage}");