namespace Solution.Models;

public class Employee
{
    public string Name { get; set; }

    public string Project {  get; set; }

    public ICollection<int> WeeklyWorkedHours { get; set;} = new List<int>();

    public int SumOfWeeklyWorkedHours => this.WeeklyWorkedHours.Sum();

    public int MostWorkedHoursOnWeek => this.WeeklyWorkedHours.Max();

    public Weekday MostWorkedHoursDay
    {
        get
        {
            List<Weekday> weekdays = Enum.GetValues(typeof(Weekday))
                                         .Cast<Weekday>()
                                         .ToList();

            int index = this.WeeklyWorkedHours.ToList()
                                              .IndexOf(this.MostWorkedHoursOnWeek);

            return weekdays[index];
        }
    }

    public Rating Rating => this.SumOfWeeklyWorkedHours switch
    {
        > 30 => Rating.Excellent,
        > 21 => Rating.Avarage,
        _ => Rating.Bad
    };

    public int WeeklySalary => this.WeeklyWorkedHours.Sum() * 10000;

    public Employee()
    {
    }

    public Employee(string name, string project, ICollection<int> weeklyWorkedHours)
    {
        Name = name;
        Project = project;
        WeeklyWorkedHours = weeklyWorkedHours;
    }
}
