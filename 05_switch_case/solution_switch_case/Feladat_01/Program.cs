Console.WriteLine("Please input the day index (1-7):");
int dayIndex = int.Parse(Console.ReadLine());

string dayName = dayIndex switch
{
    1 => "Monday",
    2 => "Tuesday",
    3 => "Wednesday",
    4 => "Thursday",
    5 => "Friday",
    6 => "Saturday",
    7 => "Sunday",
    _ => "there is not a day with that index"
};

Console.WriteLine(dayName);