int sum = 0;
int inputNumber = 0;
int limit = 0;

do
{
    Console.Write("Kérem adja meg a határértéket: ");
    string temp = Console.ReadLine();
    int.TryParse(temp, out limit);

} while (limit == 0 || limit < 100);

do
{
    int numberToAdd;
    Console.Write("Kérem adjon meg egy számot: ");
    string input = Console.ReadLine();
    bool isNumber = int.TryParse(input, out numberToAdd);
    if (isNumber)
    {
        sum += numberToAdd;
        inputNumber++;
        Console.WriteLine($"A jelenlegi összeg: {sum}, {inputNumber}. bevitelnél tart ");
    }
    else
    {
        Console.WriteLine("Nem számot adott meg");
    }

} while (sum <= limit);