var volleyballers = await FileService.ReadVolleyballersAsync("adatok.txt");

//1 - Írjuk ki a képernyőre az össz adatot
volleyballers.WriteCollectionToConsole();

//2 - Keressük ki az ütő játékosokat az utok.txt állömányba
var hitters = volleyballers.Where(x => x.Position == "ütő").ToList();
await FileService.WriteVolleyballersAsync("utok.txt", hitters);



//3 - A csapattagok.txt állományba mentsük a csapatokat és a hozzájuk tartozó játékosokat a következő formában:
//  Telekom Baku: Yelizaveta Mammadova, Yekaterina Gamova,
List<TeamsWithPlayers> teamsWithPlayers = volleyballers.GroupBy(x => x.Team)
    .Select(x => new TeamsWithPlayers(x.Key, x.Select(y => y.Name).ToList()))
    .ToList();

await FileService.WriteVolleyballersToFileByTeamsAsync("csapattagok.txt", teamsWithPlayers);




//4 - Rendezzük a játékosokat magasság szerint növekvő sorrendbe és a magaslatok.txt állományba mentsük el.
var sortedByHeight = volleyballers.OrderBy(x => x.Height).ToList();
await FileService.WriteVolleyballersAsync("magaslatok.txt", sortedByHeight);


//5 - Mutassuk be a nemzetisegek.txt állományba, hogy mely nemzetiségek képviseltetik magukat a
//röplabdavilágban mint játékosok és milyen számban.
List<NationalityWithCount> nationalitiesWithCount = volleyballers.GroupBy(x => x.Nationality)
    .Select(x => new NationalityWithCount(x.Key, x.Count()))
    .ToList();

await FileService.WriteNationalityCountsToFileAsync("nemzetisegek.txt", nationalitiesWithCount);

//6 - atlagnalmagasabbak.txt állományba keressük azon játékosok nevét és magasságát akik magasabbak mint az „adatbázisban” szereplő játékosok átlagos magasságánál.
var averageHeight = volleyballers.Average(x => x.Height);
var tallerThanAverage = volleyballers.Where(x => x.Height > averageHeight).ToList();
await FileService.WriteVolleyballersAsync("atlagnalmagasabbak.txt", tallerThanAverage);

//7 - Állítsa növekvő sorrendbe a posztok szerint a játékosok össz magasságát

var positionsWithHeightSums = volleyballers.GroupBy(x => x.Position)
    .Select(x => new PositionWithHeightSum(x.Key, x.Sum(y => y.Height)))
    .OrderBy(x => x.HeightSum)
    .ToList();

await FileService.WritePositionsWithHeightSumsToFileAsync("posztok.txt", positionsWithHeightSums);



//8 - Egy szöveges állományba, „alacsonyak.txt” keresse ki a játékosok átlagmagasságától alacsonyabb játékosokat. Az állomány tartalmazza a játékosok nevét, magasságát és hogy mennyivel alacsonyabbak az átlagnál, 2 tizedes pontossággal.
var shorterThanAverage = volleyballers.Where(x => x.Height < averageHeight).ToList();
List<VolleyballerWithDifferenceFromAverage> shorterThanAverageWithDifference = shorterThanAverage
    .Select(x => new VolleyballerWithDifferenceFromAverage(x, averageHeight))
    .ToList();

await FileService.WriteVolleyballersWithHeightDifferenceAsync("alacsonyak.txt", shorterThanAverageWithDifference);


