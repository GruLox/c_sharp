using Feladat___03;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

List<Motorcycle> LoadData()
{
    FileStream fs = new FileStream("./../../../data.json", FileMode.Open, FileAccess.Read, FileShare.None);
    StreamReader sr = new StreamReader(fs, Encoding.UTF8);
    
    string jsonData = sr.ReadToEnd();
    return JsonSerializer.Deserialize<List<Motorcycle>>(jsonData);
    
}

void WriteToConsole(string text, ICollection<Motorcycle> motorcycles)
{
    Console.WriteLine(text);
    Console.WriteLine(string.Join('\n', motorcycles));
}

void WriteSingleToConsole(string text, Motorcycle motorcycle)
{
    Console.WriteLine(text);
    Console.WriteLine(motorcycle);
}


List<Motorcycle> motorcycles = LoadData();
WriteToConsole("Data", motorcycles);

// 1 - Hány motorkerékpár van az 'adatbázisban' ?
int motorcycleCount = motorcycles.Count;


// 2 - Hány 'Honda' gyártmányú motorkerékpár van az 'adatbázisban' ?
int hondaMotorcycleCount = motorcycles.Count(m => m.Brand.ToLower() == "honda");


// 3 - Mekkora a legnyaobb köbcenti az 'adatbázisban' ?
int maxCubicCm = motorcycles.Max(m => m.Cubic);


// 4 - Melyik a legkisebb végsebesség az 'adatbázisban' ?
int minMaxSpeed = motorcycles.Min(m => m.TopSpeed);


// 5 - Van e olyan motorkerékpár az 'adatbázisban' amelyet 1960 előtt gyártottak?
bool isThereAnyMotorcycleManufacturedBefore1960 = motorcycles.Any(m => m.ReleaseYear < 1960);


// 6 - Van-e 'Honda' gyártmányú motorkerképár az 'adatbázisban' melynek beceneve 'Hornet' ?
bool isThereAnyHondaHornet = motorcycles.Any(m => m.Brand.ToLower() == "honda" && m.Nickname.ToLower() == "hornet");


// 7 - Keressük ki a 'Yamaha' gyártmányú motorkerékpárokat!
IEnumerable<Motorcycle> yamahaMotorcycles = motorcycles.Where(m => m.Brand.ToLower() == "yamaha");


// 8 -Keressük a 'Suzuki' gyártmányú motorkerékpárokat melyek 600ccm felett vannak!
IEnumerable<Motorcycle> suzukiMotorcyclesOver600Ccm = motorcycles.Where(m => m.Brand.ToLower() == "suzuki" && m.Cubic > 600);


// 9 - Keressük ki a 'Kawasaki' gyártotmányú motorkerékpárokat, melyek sebesságe nagyobb min 150km/h!
IEnumerable<Motorcycle> kawasakiMotorcyclesOver150Kmh = motorcycles.Where(m => m.Brand.ToLower() == "kawasaki" && m.TopSpeed > 150);


// 10 - Keressük ki a 'BMW' gyártotmányú motorkerékpárokat, melyeket 2010 előtt gyárottak és a motor köbcentije minimum 1000!
IEnumerable<Motorcycle> bmwMotorcyclesManufactoredBefore2010AtLeast1000Ccm = motorcycles.Where(m => m.Brand.ToLower() == "bmw" && m.ReleaseYear < 2010 && m.Cubic >= 1000); 




// 12 - Keressül a motorkerékpárok beceneveit (nickname)!
IEnumerable<string> nicknames = motorcycles.Select(m => m.Nickname).Distinct();


// 13 - Keressük azokat a motorkerékpárokat, melyek neveiben szerepel 'FZ' kifejezés!
IEnumerable<Motorcycle> fzMotorcycles = motorcycles.Where(m => m.Nickname.ToLower().Contains("fz"));


// 14 - Keressük azokat a motorkerékpárokat, melyek nevei 'C' betűvel kezdődnek!
IEnumerable<Motorcycle> motorcyclesWhoseNamesStartsWithC = motorcycles.Where(m => m.Nickname.ToLower().StartsWith('c'));



// 15 - Keressük az első motorkerékpárt az 'adatbázisunkból'!
Motorcycle firstMotorcycle = motorcycles.First();


// 16 - Keressük az utolsó motorkerékpárt az 'adatbázisunkból'!
Motorcycle lastMotorcycle = motorcycles.Last();


// 17 - Rendezzük növekvő sorrendbe gyártási év alapján az 'adatbázisban' szereplő motorkerékpárokat.
IEnumerable<Motorcycle> motorcyclesOrderedByYear = motorcycles.OrderBy(m => m.ReleaseYear);


// 18 - Rendezzük csökkenő sorrendbe a 'Honda' által gyártott motorkerékpárokat, melyek teljesítménye legalább 25kW és 2005 után gyártották őket.
IEnumerable<Motorcycle> hondaMotorcyclesOver25KwManufacturedAfter2005OrderedByPerformanceInDescendingOrder = motorcycles.Where(m => m.Brand.ToLower() == "honda" && m.KW >= 25 && m.ReleaseYear > 2005)
                                                                                   .OrderByDescending(m => m.KW);


// 19 - Melyek azok a  motorkerékpárok, melyek nem rendelkeznek becenévvel?
IEnumerable<Motorcycle> motorcyclesWithoutNickname = motorcycles.Where(m => string.IsNullOrWhiteSpace(m.Nickname));


// 20 - Mekkora az 'adatbázisban' szereplő motorkerékpárok sebességének az átlaga?
double averageMaxSpeed = motorcycles.Average(m => m.TopSpeed);


// 21 - Melyik a legyorsabb motorkerékpár? Feltételezzük, hogy csak egy ilyen van!
Motorcycle fastestMotorcycle = motorcycles.MaxBy(m => m.TopSpeed);


// 22 - Hány kategória található meg az 'adatbázisban'?
int CountOfCategories = motorcycles.Select(m => m.Category).Distinct().Count();


// 23 - Határozza meg az 'adatbázisban' talalható motorkerékpárok átlag életkorát!
double averageAgeOfMotorcycles = motorcycles.Average(m => DateTime.Now.Year - m.ReleaseYear);


// 24 - Van-e 'Java' gyártmányú motorkerékpár az 'adatbázisban'?
bool areThereAnyMotorcyclesMadeByJava = motorcycles.Any(m => m.Brand.ToLower() == "java");


// 25 - Rendezzül növekvő sorrende az 5 betűvel rendelkező gyártók motorkerékpárjait,
//         majd csökkenő sorrendbe gyártási év alapján és az eredményben csak a nevet és
//         a gyártási évet jelenítse meg!
List<MotorcycleNameAndReleaseYear> motorcyclesBy5CharacterLongBrandsOrderedByModelNameThenByReleaseYear = 
    motorcycles.Where(m => m.Brand.Length == 5)
    .OrderBy(m => m.Model)
    .ThenByDescending(m => m.ReleaseYear)
    .Select(m => new MotorcycleNameAndReleaseYear(m.Brand, m.ReleaseYear)).ToList();



   


Console.ReadLine();
