List<Employee> employees = await FileService.LoadEmployeesAsync("munkaber.txt");

//2 - Milyen összeget kell kifizetni munkabérként, ha egy munkaóra 10.000HUF?
int sumOfEmployeesWeeklyWorkedHours = employees.Sum(x => x.WeeklySalary);

//3 - Ki dolgozta a héten a legtöbb munkaórát?
Employee mostHoursWorkedEmployee = employees.MaxBy(x => x.SumOfWeeklyWorkedHours);

//4 -	Számítsuk ki a dolgozók fizetését, ha tudjuk, hogy 1 munkaóra az 10.000HUF
//      és a fizetes_2024-03.txt állományba mentsük
//      (2024 a kifizetés éve, 03 a kifizetés hónapja)
//      el a megadott minta szerint: Hapci \t 360000 HUF).
string fileName = $"fizetes_{DateTime.Now:yyyy-MM}.txt";
await FileService.WriteWeeklySalaryAsync(fileName, employees);

/*
-	Keresse ki csoportba bontva a dolgozókat ledolgozott órák után. 
    Három csoport létezik: rossz, átlagos és kiváló. 
    Rossznak az számít, aki nem érte el a heti 21 órát,
    átlagos az, aki 30 óráig teljesített és a kiváló csoportba az tartozik,
    aki a héten 30 óra feletti óraszámmal rendelkezik.
    Az eredményt a mintának megfelelően írja ki a képernyőre.
    (a minta csak reprezentatív, nem a valós eredményt mutathatja).
*/
Dictionary<Rating, IEnumerable<string>> ratedEmployees =
    employees.GroupBy(x => x.Rating)
             .ToDictionary(
                 x => x.Key,
                 v => v.Select(s => $"{s.Name} ({s.SumOfWeeklyWorkedHours})")
             );
WriteRatedEmployeesToConsole(ratedEmployees);

/*
-	Melyik projecten dolgozókra kell a kifizetés hetén a legtöbb forrást biztosítani?
    A mintában a 2024 az elszámolás éve, 03 az elszámolás hónapja és a 04 az elszámolás
    hónapjának a hete. Az elszámolás hónap hetének meghatározására használhatja a megadott
    GetWeekNumberOfMonth függvényt! 
*/

string mostResourcesNeededProject = employees.GroupBy(x => x.Project)
                                             .OrderByDescending(x => x.Sum(s => s.WeeklySalary))
                                             .Select(x => x.Key)
                                             .First();

/*
-	Ki/Kik és melyik nap dolgozta/dolgozták a legtöbb órát az elszámolás hetén?
    Az eredményt írja ki a képernyőre tetszőlegesen, de tartalmaznia kell a dolgozó nevét,
    ledolgozott óráinak számát és a napot! 
*/
int maxWorkedHours = employees.Max(x => x.MostWorkedHoursOnWeek);
List<Employee> mostHoursWorkedEmployees = employees.Where(x => x.MostWorkedHoursOnWeek == maxWorkedHours)
                                                   .ToList();

void WriteRatedEmployeesToConsole(Dictionary<Rating, IEnumerable<string>> ratedEmployees)
{
    foreach (KeyValuePair<Rating, IEnumerable<string>> ratedEmployee in ratedEmployees)
    {
        Console.WriteLine($"{ratedEmployee.Key}:");

        foreach (string eployeeName in ratedEmployee.Value)
        {
            Console.WriteLine($"\t- {eployeeName}");
        }
    }
}
