namespace Project.Models;

public class StudentWithSubjects : Student
{
    public ICollection<Subject> Subjects { get; set; }

    public StudentWithSubjects()
    {
        Subjects = new List<Subject>();
    }

    public StudentWithSubjects(Student student, ICollection<Subject> subjects)
    {
        Id = student.Id;
        Name = student.Name;
        Subjects = subjects;
    }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}";
    }
}
