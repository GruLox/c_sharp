namespace Feladat_07;

public class DailyExpense
{
    public Days Day { get; set; }

    public int Expense { get; set; }

    public DailyExpense() {}

    public DailyExpense(Days day, int expense)
    {
        Day = day;
        Expense = expense;
    }

    public override string ToString()
    {
        return $"{Day} => {Expense}";
    }
}
