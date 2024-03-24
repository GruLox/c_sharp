namespace Project.Models;

public class Subject
{
    public int Id { get; set; }
    public SubjectName Name { get; set; }
    public int StudentId { get; set; }
    public ICollection<int> Grades { get; set; } = new List<int>();

    public Subject() { }
    public Subject(int id, SubjectName name, int studentId, ICollection<int> grades)
    {
        Id = id;
        Name = name;
        StudentId = studentId;
        Grades = grades;
    }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}";
    }
}
