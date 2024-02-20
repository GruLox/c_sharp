public class Student
{
    public string Name { get; set; }
    public double Average { get; set; }

    public Grade Grade => Average switch
    {
        < 2 => Grade.Elegtelen,
        < 3 => Grade.Elegseges,
        < 4 => Grade.Jo,
        < 5 => Grade.Jeles,
        5 => Grade.Kituno,
        _ => throw new Exception("Invalid grade")
    };

    public Student() { }
    public Student(string name, double average)
    {
        Name = name;
        Average = average;
    }

    public override string ToString()
    {
        return $"{Name} -> {Average}";
    }
    
}
