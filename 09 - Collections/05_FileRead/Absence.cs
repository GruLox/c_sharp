public class Absence
{
    public string Name { get; set; }

    public string Class { get; set; }

    public int FirstDay { get; set; }

    public int LastDay { get; set; }

    public int HoursOfAbsence { get; set; }

    public Absence() { }

    public Absence(string name, string @class, int firstDay, int lastDay, int hoursOfAbsence)
    {
        Name = name;
        Class = @class;
        FirstDay = firstDay;
        LastDay = lastDay;
        HoursOfAbsence = hoursOfAbsence;
    }

    public override string ToString()
    {
        return $"{Name} ({Class}): {HoursOfAbsence} óra";
    }

}

