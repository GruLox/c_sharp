Console.Write("Please type in the name of your favorite band: ");
string bandName = Console.ReadLine();

Console.Write("Please type in the name of their favorite song of yours: ");
string songName = Console.ReadLine();

Console.Write("Please type in the duration of that song: ");
double songDuration = double.Parse(Console.ReadLine());

Console.WriteLine($"Az ön kedvenc együttesének {bandName} a legjobb zeneszáma {songName} melynek hossza {songDuration}");

