namespace Project.Models;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Student() { }

    public Student(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}";
    }
}
