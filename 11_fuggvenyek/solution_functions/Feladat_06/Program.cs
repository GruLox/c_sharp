using IOLibrary;

int score = ExtendedConsole.ReadInteger("Kérem adja meg a pontszámot: ", 100, 0);

Console.WriteLine($"Az érdemjegye: {GetMark(score)}");

string GetMark(int score)
{
    return score switch
    {
        < 50 => "1",
        < 60 => "2",
        < 70 => "3",
        < 85 => "4",
        < 100 => "5",
        _ => "Invalid",
    };
}