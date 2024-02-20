
List<Student> students = await FileService.ReadStudentsFromFileV2Async("adatok.txt");

//1-Írjuk ki minden diák adatát a képernyőre!
students.WriteCollectionToConsole<Student>();




//2 - Hány diák jár az osztályba?
int studentCount = students.Count;
Console.WriteLine($"Az osztályba {studentCount} diák jár.");
Console.WriteLine();


//3 - Mennyi az osztály átlaga?
double classAverage = students.Average(s => s.Average);
Console.WriteLine($"Az osztály átlaga: {classAverage:0.00}");
Console.WriteLine();



//4 - Keressük a legtöbb pontot elért érettségizőt és írjuk ki az adatait a képernyőre.
Student bestStudent = students.MaxBy(s => s.Average)!;
Console.WriteLine($"A legtöbb pontot elért érettségiző: {bestStudent}");


//5 - atlagfelett.txt allományba keressük ki azon tanulókat kiknek pontjai meghaladják az átlagot!
List<Student> aboveAverageStudents = students.Where(s => s.Average > classAverage).ToList();
await FileService.WriteToFileV1Async("atlagfelett", aboveAverageStudents);




//6 - Van e kitünő tanulónk?
bool hasExcellentStudent = students.Any(s => s.Average == 5.00);




//7 - Hány elégtelen, elégséges, jó, jeles és kitünő tanuló van az osztályban?
//    Értékhatárok:
//	-elégtelen, ha: 0.00 - 1.99
//    - elégséges, ha: 2.00 - 2.99
//    - jó, ha: 3.00 - 3.99
//    - jeles, ha: 4.00 - 4.99
//    - kitünő, ha: 5.00
Dictionary<Grade, int> gradeCounts = new Dictionary<Grade, int>
{
    [Grade.Elegtelen] = students.Count(s => s.Grade == Grade.Elegtelen),
    [Grade.Elegseges] = students.Count(s => s.Grade == Grade.Elegseges),
    [Grade.Jo] = students.Count(s => s.Grade == Grade.Jo),
    [Grade.Jeles] = students.Count(s => s.Grade == Grade.Jeles),
    [Grade.Kituno] = students.Count(s => s.Grade == Grade.Kituno)
};

/*----------------------------------------V2----------------------------------------*/

Dictionary<Grade, int> gradeCountsV2 = new Dictionary<Grade, int>();

foreach (var grade in Enum.GetValues<Grade>())
{
    gradeCountsV2[grade] = students.Count(s => s.Grade == grade);
}

foreach (var (grade, count) in gradeCountsV2)
{
    Console.WriteLine($"{grade}: {count}");
}





    

Console.ReadKey();