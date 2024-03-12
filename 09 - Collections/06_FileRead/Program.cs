using Custom.Library.ConsoleExtensions;
using System.Collections.Generic;

var dancePairs = await FileService.ReadDancePairsFromFileAsync("tancrend.txt");

//Olvassa be a tancrend.txt állományban talált adatokat, s annak felhasználásával oldja 
//meg a következő feladatokat! 
//2. Írassa ki a képernyőre, hogy melyik volt az elsőként és melyik az utolsóként bemutatott 
//tánc neve! 
string nameOfFirstDance = dancePairs.Single(p => p.Id == 0).Dance;
string nameOfLastDance = dancePairs.Single(p => p.Id == dancePairs.Count - 1).Dance;
Console.WriteLine($"Az első bemutatott tánc: {nameOfFirstDance}");
Console.WriteLine($"Az utolsó bemutatott tánc: {nameOfLastDance}");

//3. Hány pár mutatta be a sambát? A választ jelenítse meg a képernyőn! 
int numberOfSambaDances = dancePairs.Count(p => p.Dance == "samba");
Console.WriteLine($"A sambát {numberOfSambaDances} pár mutatta be.");

//4. Írassa ki a képernyőre, hogy Vilma mely táncokban szerepelt! 
var dancesVilmaParticipatedIn = dancePairs.Where(p => p.FemaleDancer == "Vilma").Select(p => p.Dance).Distinct();
Console.WriteLine("Vilma a következő táncokban szerepelt:");
dancesVilmaParticipatedIn.WriteCollectionToConsole();


//5. Kérje be egy tánc nevét, majd írassa ki a képernyőre, hogy az adott táncot Vilma kivel 
//mutatta be! Például ha a bekért tánc a samba, és Vilma párja Bertalan volt, akkor 
//„A samba bemutatóján Vilma párja Bertalan volt.” szöveg jelenjen meg! 
//Ha Vilma az adott tánc bemutatóján nem szerepelt, akkor azt írja ki a képernyőre, hogy 
//„Vilma nem táncolt samba-t.”. 
string danceName = ExtendedConsole.ReadString("Adjon meg egy táncot: ");
var vilmasDancePartner = dancePairs.SingleOrDefault(p => p.Dance == danceName && p.FemaleDancer == "Vilma")?.MaleDancer;
if (vilmasDancePartner is not null)
{
    Console.WriteLine($"A {danceName} bemutatóján Vilma párja {vilmasDancePartner} volt.");
}
else
{
    Console.WriteLine($"Vilma nem táncolt {danceName}-t.");
}



//6.Készítsen listát a bemutatón részt vett fiúkról és lányokról! A listát a szereplok.txt
//nevű szöveges állományba mentse el a következő formátumban: a neveket vesszők 
//válasszák el egymástól, de az utolsó név után már ne szerepeljen írásjel. Például: 
//Lányok: Lujza, Katalin, Andrea, Emma 
//Fiúk: Ferenc, Ambrus, Andor, Kelemen, Bertalan
var girls = dancePairs.Select(p => p.FemaleDancer).Distinct();
var guys = dancePairs.Select(p => p.MaleDancer).Distinct();
await FileService.AppendToFileAsync("Lányok: ", girls, "szereplők.txt");
await FileService.AppendToFileAsync("Fiúk: ", guys, "szereplők.txt");



//7. Írja ki a képernyőre, hogy melyik fiú szerepelt a legtöbbször a fiúk közül, és melyik lány 
//a lányok közül! Ha több fiú, vagy több lány is megfelel a feltételeknek, akkor valamennyi 
//fiú, illetve valamennyi lány nevét írja ki!
int maxGuyParticipation = dancePairs.GroupBy(p => p.MaleDancer).Max(g => g.Count());
var mostFrequentGuys = dancePairs.GroupBy(p => p.MaleDancer).Where(g => g.Count() == maxGuyParticipation).Select(g => g.Key);
await FileService.AppendToFileAsync("A legtöbbször szereplő fiúk: ", mostFrequentGuys, "max.txt");
int maxGirlParticipation = dancePairs.GroupBy(p => p.FemaleDancer).Max(g => g.Count());
var mostFrequentGirls = dancePairs.GroupBy(p => p.FemaleDancer).Where(g => g.Count() == maxGirlParticipation).Select(g => g.Key);
await FileService.AppendToFileAsync("A legtöbbször szereplő lányok: ", mostFrequentGirls, "max.txt");


Console.ReadKey();