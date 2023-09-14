Console.Write("Please type in the release date: ");
int releaseYear = int.Parse(Console.ReadLine());

Console.Write("Please type in the name of the director: ");
string directorName = Console.ReadLine();

Console.Write("Please type in the title of the movie: ");
string movieTitle = Console.ReadLine();

Console.Write("Please type in the name of the lead actor: ");
string leadActorName = Console.ReadLine();

Console.WriteLine($"{releaseYear}-ban {directorName} rendezésében megjelent a/az {movieTitle} című film {leadActorName} főszereplésével.");
