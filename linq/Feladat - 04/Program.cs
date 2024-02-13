using Feladat___04;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;

List<Movie> LoadData()
{
    JsonSerializerOptions options = new JsonSerializerOptions
    {
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        PropertyNameCaseInsensitive = true,
        WriteIndented = true,
    };

    options.Converters.Add(new DateFormatConverter());

    FileStream fs = new FileStream("./../../../data.json", FileMode.Open, FileAccess.Read, FileShare.None);
    StreamReader sr = new StreamReader(fs, Encoding.UTF8);
    
    string jsonData = sr.ReadToEnd();
    return JsonSerializer.Deserialize<List<Movie>>(jsonData, options);

}

 void WriteToConsole(string text, ICollection<Movie> movies)
{
    Console.WriteLine(text);
    Console.WriteLine(string.Join('\n', movies));
}

 void WriteSingleToConsole(string text, Movie movie)
{
    Console.WriteLine(text);
    Console.WriteLine(movie);
}


List<Movie> movies = LoadData();
WriteToConsole($"Data ({movies.Count})", movies);

// 1 - Hány film adatát dolgozzuk fel?
int movieCount = movies.Count;

// 2 - Mekkora bevételt hoztak a filmek Amerikában?
long totalUsGrossRevenue = movies.Sum(m => m.USGross ?? 0);

// 3 - Mekkora bevételt hoztak a filmek Világszerte?
long totalWorldwideGrossRevenue = movies.Sum(m => m.WorldwideGross ?? 0);

// 4 - Hány film jelent meg az 1990-es években?
long countOfMoviesReleasedIn1990s = movies.Count(m => m.ReleaseDate.Year >= 1990 && m.ReleaseDate.Year < 2000);

// 5 - Hányan szavaztak összessen az IMDB-n?
long totalVotesOnIMDB = movies.Sum(m => m.IMDBVotes ?? 0);

// 6 - Hányan szavaztak átlagossan az IMDB-n?
double averageVotesOnIMDB = movies.Average(m => m.IMDBVotes ?? 0);

// 7 - A filmek  világszerte átlagban mennyit hoztak a konyhára?
double averageWorldwideGrossRevenue = movies.Average(m => m.WorldwideGross ?? 0);

// 8 - Hány filmet rendezett 'Christopher Nolan' ?
long countOfMoviesDirectedByChristopherNolan = movies.Count(m => m.Director?.ToLower() == "christopher nolan");

// 9 - Melyik filmeket rendezte 'James Cameron'?
IEnumerable<Movie> moviesDirectedByJamesCameron = movies.Where(m => m.Director?.ToLower() == "james cameron");

// 10 - Keresse ki a 'Fantasy' kaland (Adventure) zsáner kategóriájjú filmeket.
IEnumerable<Movie> fantasyAdventureMovies = movies.Where(m => m.MajorGenre?.ToLower() == "fantasy");

// 11 - Kik rendeztek akció (Action) filmeket és mikor?
List<DirectorWithReleaseDates> actionMovieDirectorsWithReleaseDates = movies
    .Where(m => m.MajorGenre?.ToLower() == "action" && m.Director is not null)
    .GroupBy(m => m.Director)
    .Select(g => new DirectorWithReleaseDates(g.Key,  g.Select(m => m.ReleaseDate).ToList())
    {
        Director = g.Key,
        ReleaseDates = g.Select(m => m.ReleaseDate).ToList()
    }).ToList();

// 12 - 'Paramount Pictures' horror filmjeinek cime?
IEnumerable<string> paramountPicturesHorrorMovieTitles = movies
    .Where(m => m.Distributor.ToLower() == "paramount pictures" && m.MajorGenre?.ToLower() == "horror")
    .Select(m => m.Title);

// 13 - Van-e olyan film melyet 'Tom Crusie' rendezett?
bool isThereAnyMovieDirectedByTomCruise = movies.Any(m => m.Director?.ToLower() == "tom cruise");

// 14 - A 'Little Miss Sunshine' filme mekkora össz bevételt hozott?
long littleMissSunshineTotalGrossRevenue = movies
    .FirstOrDefault(m => m.Title.ToLower() == "little miss sunshine")?.WorldwideGross ?? 0;
    

// 15 - Hány olyan film van amely az IMDB-n 6 feletti osztályzatot ért el és a 'Rotten Tomatoes'-n pedig legalább 25-t?
long countOfMoviesWithIMDBRatingOver6AndRottenTomatoesRatingOver25 = movies
    .Count(m => m.IMDBRating > 6 && m.RottenTomatoesRating >= 25);

// 16 - 'Michael Bay' filmjei átlagban mekkora bevételt hoztak?
double averageGrossRevenueOfMichaelBayMovies = movies
    .Where(m => m.Director.ToLower() == "michael bay")
    .Average(m => m.WorldwideGross ?? 0);

// 17 - Melyek azok a 'Michael Bay' a 'Walt Disney Pictures' által forgalmazott fimek melyek legalább 150min hosszúak.
IEnumerable<Movie> longMoviesDirectedByMichaelBayAndDistributedByWaltDisneyPictures = movies
    .Where(m => m.Director.ToLower() == "michael bay" && m.Distributor.ToLower() == "walt disney pictures" && m.RunningTime >= 150);

// 18 - Listázza ki a forgalmazókat úgy, hogy mindegyik csak egyszer jelenjen meg!
IEnumerable<string> distinctDistributors = movies.Select(m => m.Distributor).Distinct();

// 19 - Rendezze a filmeket az 'IMDB Votes' szerint  növekvő sorrendbe.
IEnumerable<Movie> moviesOrderedByIMDBVotes = movies.OrderBy(m => m.IMDBVotes);

// 20 - Rendezze a filmeket címük szerint csökkenő sorrendbe!
IEnumerable<Movie> moviesOrderedByTitle = movies.OrderByDescending(m => m.Title);

// 21 - Melyek azok a filmek melyek hossza meghaladja a 120 percet?
IEnumerable<Movie> moviesLongerThan120Minutes = movies.Where(m => m.RunningTime > 120);

// 22 - Hány film jelent meg december hónapban?
long countOfMoviesReleasedInDecember = movies.Count(m => m.ReleaseDate.Month == 12);

// 23 - Egyes besorolásokban (Rating) hány film található?
IEnumerable<RatingWithCount> ratingCounts = movies
    .GroupBy(m => m.Rating)
    .Select(g => new RatingWithCount
    {
        Rating = int.Parse(g.Key),
        Count = g.Count()
    });

// 24 - Keresse ki azokat a filmeket melyeket 'Ron Howard' rendezett a 2000 években, 'PG-13' bsorolású, lagalább 80 perc hosszú és az IMDB legalább 6.5 átlagot ért el.
IEnumerable<Movie> moviesDirectedByRonHowardIn2000sThatArePG13AndAbove65 = movies
    .Where(m => m.Director.ToLower() == "ron howard" && m.ReleaseDate.Year >= 2000 && 
    m.Rating == "PG-13" && m.RunningTime >= 80 && m.IMDBRating >= 6.5);

// 25 - A 'Lionsgate' kiadónál kik rendeztek filmeket?
IEnumerable<string> directorsOfLionsgateMovies = movies
    .Where(m => m.Distributor.ToLower() == "lionsgate")
    .Select(m => m.Director);

// 26 - Az 'Universal' forgalmazó átlagban mennyit kültött film forgatására?
double averageProductionBudgetOfUniversalMovies = movies
    .Where(m => m.Distributor.ToLower() == "universal")
    .Average(m => m.ProductionBudget ?? 0);

// 27 - Az 'IMDB Votes' alapján melyek azok a filmek, melyeket többen értékeltek min 30 000-n?
IEnumerable<Movie> moviesWithMoreThan30000IMDBVotes = movies.Where(m => m.IMDBVotes >= 30000);

// 28 - Az 'American Pie' című filmnek hány része van?
long countOfAmericanPieMovies = movies.Count(m => m.Title?.ToLower().Contains("american pie") ?? false);

// 29 - Van-e olyan film melynek a címében szerepel a 'fantasy' szó és a zsánere 'Adventure'?
bool isThereAFantasyAdventureMovie = 
    movies.Any(m => m.Title?.ToLower().Contains("fantasy") ?? false && 
               m.MajorGenre?.ToLower() == "adventure");


// 30 - Átlagban hányan szavaztak az IMDB-n?
double averageIMDBVotes = movies.Average(m => m.IMDBVotes ?? 0);

// 31 - Kik rendeztek a 'Warner Bros.' forgalmazónál dráma filmeket 1970 és 1975 közt melyre az 'IMDB Votes' alapján többen szavaztak az átlagnál?
IEnumerable<string> directorsOfWarnerBrosDramaMoviesWithMoreVotesThanAverage = movies
    .Where(m => m.Distributor.ToLower() == "warner bros." &&
           m.MajorGenre?.ToLower() == "drama" && m.ReleaseDate.Year >= 1970 && 
           m.ReleaseDate.Year <= 1975 && m.IMDBVotes > averageIMDBVotes)
    .Select(m => m.Director);

// 32 - Van e olyan film amely karácsony napján jelent meg?
bool isThereAMovieReleasedOnChristmas = movies.Any(m => m.ReleaseDate.Month == 12 && m.ReleaseDate.Day == 25);

// 33 - 'Spider-Man' című filmek USA-ban mekkora bevételt hoztak?
long totalUSGrossRevenueOfSpiderManMovies = movies
    .Where(m => m.Title?.ToLower().Contains("spider-man") ?? false).Sum(m => m.USGross ?? 0);




// 34 - Keresse ki  szuperhősös (Super Hero) filmek címeit.
IEnumerable<string> superHeroMovieTitles = movies.Where(m => m.MajorGenre?.ToLower() == "super hero").Select(m => m.Title);

// 35 - Kérje le az első 10 filmet.
IEnumerable<Movie> first10Movies = movies.Take(10);

// 36 - Kérje le a 30 és 40 közti filmeket a sorból, ahol a 30 és a 40 indexek
IEnumerable<Movie> moviesBetween30And40 = movies.Skip(30).Take(10);


