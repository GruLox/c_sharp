namespace Project.Models;

public class StudentWithSubjects : Student
{
    public ICollection<Subject> Subjects { get; set; }

    public StudentWithSubjects()
    {
        Subjects = new List<Subject>();
    }

    public StudentWithSubjects(int id, string name, ICollection<Subject> subjects) : base(id, name)
    {
        Subjects = subjects;
    }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}";
    }
}
