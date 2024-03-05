using Custom.Library.ConsoleExtensions;

var absences = await FileService.ReadAbsencesFromFileAsync("szeptember.csv");

//2.Határozza meg, és írja ki a képernyőre, hogy a diákok összesen hány órát mulasztottak 
//ebben a hónapban. 
int sumOfAbsences = absences.Sum(a => a.HoursOfAbsence);


//3. Kérjen be a felhasználótól 
// egy napot 1 és 30 között
// egy tanuló nevét
int n = ExtendedConsole.ReadInteger("Nap: ", 30, 1);
string name = ExtendedConsole.ReadString("Tanuló neve: ");

//4. Írja ki a képernyőre, hogy az előző feladatban beért tanulónak volt-e hiányzása! A „A 
//tanuló hiányzott szeptemberben” vagy „A tanuló nem hiányzott 
//szeptemberben” szöveget jelenítse meg
bool wasAbsent = absences.Any(a => a.Name == name);
Console.WriteLine($"A tanuló {(wasAbsent ? "hiányzott" : "nem hiányzott")} szeptemberben");


//5. Írja ki a képernyőre azon tanulók nevét és osztályát a minta szerint, akik a 3. feladatban
//bekért napon hiányoztak! (Ha a 3. feladatot nem tudta megoldani, akkor a 19-ei nappal 
//dolgozzon!) Ha nem volt hiányzó, akkor a „Nem volt hiányzó” szöveget jelenítse 
//meg!
var absentStudents = absences.Where(a => a.FirstDay <= n && a.LastDay >= n).ToList();
if (absentStudents.Count == 0)
{
    Console.WriteLine("Nem volt hiányzó");
}
else
{
    absentStudents.WriteCollectionToConsole();
}


//6. Készítsen összesítést, amely osztályonként fájlba írja a mulasztott órák számát! Az
//osszesites.csv nevű fájl tartalmazza az osztályt és a mulasztott órák számának 
//összegét

var summary = absences.GroupBy(a => a.Class)
    .Select(g => new ClassesWithAbsenceCount(g.Key, g.Sum(a => a.HoursOfAbsence)))
    .ToList();

await FileService.WriteAbsenceSummaryToFile("osszesites.csv", summary);