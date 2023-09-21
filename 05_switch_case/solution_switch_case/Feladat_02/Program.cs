Console.WriteLine("Give me the name of a month: ");
string month = Console.ReadLine().ToLower();

int? monthIndex = month switch
{
    "january" => 1,
    "february" => 2,
    "march" => 3,
    "april" => 4,
    "may" => 5,
    "june" => 6,
    "july" => 7,
    "august" => 8,
    "september" => 9,
    "october" => 10,
    "november" => 11,
    "december" => 12,
    _ => null
};


Console.WriteLine(monthIndex is null ? "Nincs ilyen hónap" : $"{monthIndex}" );