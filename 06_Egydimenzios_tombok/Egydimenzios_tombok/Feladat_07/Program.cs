using Custom.Library.ConsoleExtensions;
using Feladat_07;

const int DAY_COUNT = 7;

DailyExpense[] expenses = GetDailyExpenses();
Console.Clear();

Console.WriteLine("Weekly expenses: ");
PrintExpensesToConsole(expenses);

int weeklyExpensesSum = expenses.Sum(dailyExpense => dailyExpense.Expense);
Console.WriteLine($"\n\nTotal expense: {weeklyExpensesSum}");

DailyExpense dayWithTheLeastExpense = GetDayWithTheLeastExpense(expenses);
Console.WriteLine($"Day with the least expense: {dayWithTheLeastExpense.Day}: {dayWithTheLeastExpense.Expense}");


bool hasExpenseEqualTo10000 = expenses.Any(x => x.Expense == 10000);
Console.WriteLine($"{(hasExpenseEqualTo10000 ? "volt" : "nem volt")} 10.000Ft-os kiadás.");




static DailyExpense[] GetDailyExpenses()
{
    DailyExpense[] expenses = new DailyExpense[DAY_COUNT];
    string[] weekdays = Enum.GetNames(typeof(Days));

    for (int i = 0; i < DAY_COUNT; i++)
    {
        string day = weekdays[i];
        int expense = ExtendedConsole.ReadInteger($"{day}: ", int.MaxValue, 0);

        expenses[i] = new DailyExpense(Enum.Parse<Days>(day), expense);
    }

    return expenses;
}

static void PrintExpensesToConsole(DailyExpense[] expenses)
{
    foreach (var expense in expenses)
    {
        Console.WriteLine(expense);
    }
}

static DailyExpense GetDayWithTheLeastExpense(DailyExpense[] expenses)
{
    int leastExpense = expenses.Min(dailyExpense => dailyExpense.Expense);
    DailyExpense dayWithTheLeastExpense = expenses.First(dailyExpense => dailyExpense.Expense == leastExpense);

    return dayWithTheLeastExpense;
}