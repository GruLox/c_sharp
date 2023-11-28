namespace Feladat_11;

public class Worker
{
    const int BASE_WAGE = 1000;
    const int OVERTIME_WAGE = 1500;

    public string Name { get; set; }
    public int HoursWorked { get; set; }

    public double Salary
    {
        get
        {
            return HoursWorked <= 40 ? HoursWorked * BASE_WAGE : 40 * BASE_WAGE + (HoursWorked - 40) * OVERTIME_WAGE;
        }
    }

    public Worker(string name, int hoursWorked)
    {
        Name = name;
        HoursWorked = hoursWorked;
    }

    public override string ToString()
    {
        return $"{Name} {HoursWorked} órát dolgozott és {Salary} Ft-ot keresett.";
    }
}

