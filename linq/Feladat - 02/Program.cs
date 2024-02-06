using Feladat___02;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


List<Game> games = new List<Game>();

void LoadData()
{
    using FileStream fs = new FileStream("./../../../data.json", FileMode.Open, FileAccess.Read, FileShare.None);
    using StreamReader sr = new StreamReader(fs, Encoding.UTF8);
    
    string jsonData = sr.ReadToEnd();
    games = JsonConvert.DeserializeObject<List<Game>>(jsonData);
}

void WriteToConsole(string text, ICollection<Game> games)
{
    Console.WriteLine(text);
    Console.WriteLine(string.Join('\n', games));
}

void WriteSingleToConsole(string text, Game game)
{
    Console.WriteLine(text);
    Console.WriteLine(game);
}


LoadData();
WriteToConsole("Data", games);

/*
    Hány adat van a listában?
*/
int numberOfGames = games.Count;


/*
    Keressük ki azon játékokat, melyek MMORPG tipusuak (genre).
*/
var mmorpgGames = games.Where(g => g.Genre == "MMORPG");


/*
Keressük ki azon játékokat, melyek 2013-ban jelentek meg.
*/
var gamesReleasedIn2013 = games.Where(g => g.ReleaseDate.StartsWith("2013"));


/*
Keressük ki azon játékokat, melyek Darkflow Distribution KFR fejlesztett.
*/
var gamesDevelopedByDarkflow = games.Where(g => g.Developer == "Darkflow Distribution KFR");

/*
Keressük ki hány shooter játék van a listában.
*/
int numberOfShooterGames = games.Count(g => g.Genre.ToLower() == "shooter");


/*
Van-e olyan játék melyet Cryptic Studios fejleszett?
*/
bool isThereAnyGameDevelopedByCrypicStudios = games.Any(g => g.Developer == "Cryptic Studios");

/*
Keressük ki azon játékokat, melyek a címében (title) szerepel a ,,winter,, szó.
*/
var gamesWithTitlesContainingWinter = games.Where(g => g.Title.Contains("winter"));

/*
Keressük ki a platformokat, de úgy, hogy mindegyik csak egyszer forduljon elő az eredménybe.
*/
var distinctPlatforms = games.Select(g => g.Platform).Distinct();

/*
Keressük ki , hogy típusonként (genre) hány játék van.
*/
var gamesByGenre = games.GroupBy(g => g.Genre).Select(g => new GamesByGenre(g.Key, g.Count()));


/*
Keressük ki az Electronic Arts álltal fejlesztett játékokat, melyek shooter típusúak.
*/
var eaShooterGames = games.Where(g => g.Publisher == "Electronic Arts" && g.Genre.ToLower() == "shooter");

/*
Keressük ki a listában szereplő fejlesztők  játékainak címét.
*/
var titlesByDeveloper = games.GroupBy(g => g.Developer)
                             .Select(g => new TitlesByDeveloper(g.Key, g.Select(g => g.Title).ToList()));

/*
Keressük ki azt a játékot mely legkorábban jelent meg.
*/
var earliestGame = games.MinBy(g => DateTime.Parse(g.ReleaseDate));

/*
Keressük ki azon játékok címét, melyeket az Ubisoft jelenített meg, 
a Blue Byte fejlesztett ki 2010 és 2015 közt.
*/
var titlesOfBlueByteGamesPublishedByUbisoft = games.Where(g => g.Publisher == "Ubisoft" && g.Developer == "Blue Byte" && 
                                                        DateTime.Parse(g.ReleaseDate).Year >= 2010 && 
                                                        DateTime.Parse(g.ReleaseDate).Year <= 2015)
                                                        .Select(g => g.Title);
