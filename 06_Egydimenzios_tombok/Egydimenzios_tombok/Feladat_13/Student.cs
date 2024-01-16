namespace Feladat_13;

public class Student
{
    public string Name { get; set; }
    public int Savings { get; set; }

    public Student(string name, int savings)
    {
        Name = name;
        Savings = savings;
    }

    public override string ToString()
    {
        return $"{Name} - {Savings} Ft";
    }
}
