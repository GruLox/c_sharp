using Custom.Library.ConsoleExtensions;
using Feladat_13;

Student[] students = GetStudents(3);
students = students.OrderBy(s => s.Savings).ToArray();


int totalSavings = students.Sum(s => s.Savings);
Console.WriteLine($"Az összes megtakarítás: {totalSavings}");

double averageSavings = (double)totalSavings / students.Length;
Console.WriteLine($"A megtakarítások átlaga: {averageSavings}");

Student studentWithMostSavings = students.Last();
Console.WriteLine($"A legtöbbet megtakarító tanuló: {studentWithMostSavings}");

Student studentWithLeastSavings = students.First();
Console.WriteLine($"A legkevesebbet megtakarító tanuló: {studentWithLeastSavings}");

Student[] studentsWithSavingsAbove2000 = students.Where(s => s.Savings > 2000).ToArray();
Console.WriteLine("2000 Ft feletti megtakarítású tanulók:");
foreach (var student in studentsWithSavingsAbove2000)
{
    Console.WriteLine(student);
}

bool wasThereAnyStudentWithoutSavings = students.Any(s => s.Savings == 0);
Console.WriteLine($"{(wasThereAnyStudentWithoutSavings ? "volt" : "nem volt")} olyan tanuló, akinek nem volt megtakarítása.");

Student[] studentsWithBelowAverageSavings = students.Where(s => s.Savings < averageSavings).ToArray();
Console.WriteLine("Átlag alatti megtakarítással rendelkező tanulók:");
foreach (var student in studentsWithBelowAverageSavings)
{
    Console.WriteLine(student);
}

static Student[] GetStudents(int count)
{
    Student[] students = new Student[count];
    for (int i = 0; i < students.Length; i++)
    {
        string name = ExtendedConsole.ReadString("Tanuló neve: ");
        int savings = ExtendedConsole.ReadInteger("Megtakarítás: ", int.MaxValue, 0);
        students[i] = new Student(name, savings);
    }
    return students;

}