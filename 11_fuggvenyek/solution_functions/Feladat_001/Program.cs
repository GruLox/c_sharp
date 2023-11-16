using IOLibrary;

string namePrompt = "Kérem adja meg a nevét: ";
string name = ExtendedConsole.ReadString(namePrompt);

string birthYearPrompt = "Kérem adja meg a születési évét: ";
int birthYear = ExtendedConsole.ReadInteger(birthYearPrompt, DateTime.Now.Year);

int age = CalculateAge(birthYear);
Console.WriteLine($"{name}, ön {age} éves.");


int CalculateAge(int birthYear) => DateTime.Now.Year - birthYear;

