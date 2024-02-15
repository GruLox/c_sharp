
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
//7 - Hány elégtelen, elégséges, jó, jeles és kitünő tanuló van az osztályban?
//    Értékhatárok:
//	-elégtelen, ha: 0.00 - 1.99
//    - elégséges, ha: 2.00 - 2.99
//    - jó, ha: 3.00 - 3.99
//    - jeles, ha: 4.00 - 4.99
//    - kitünő, ha: 5.00

Console.ReadKey();