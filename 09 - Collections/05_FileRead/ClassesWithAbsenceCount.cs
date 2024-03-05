public class ClassesWithAbsenceCount
{
    public string ClassName { get; set; }
    public int AbsenceCount { get; set; }

    public ClassesWithAbsenceCount()
    {
    }

    public ClassesWithAbsenceCount(string className, int absenceCount)
    {
        ClassName = className;
        AbsenceCount = absenceCount;
    }

    public override string ToString()
    {
        return $"{ClassName};{AbsenceCount}";
    }

}
