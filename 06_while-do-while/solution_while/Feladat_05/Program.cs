int sum = 0;
int inputNumber = 0;
int limit = 0;

do
{
    Console.Write("Kérem adja meg a határértéket: ");
    string temp = Console.ReadLine();
    int.TryParse(temp, out limit);

} while (limit < 100);

do
{
    Console.Write("Kérem adjon meg egy számot: ");
    string input = Console.ReadLine();
    bool isNumber = int.TryParse(input, out int numberToAdd);
    if (isNumber)
    {
        sum += numberToAdd;
        inputNumber++;
        Console.WriteLine($"A jelenlegi összeg: {sum}, {inputNumber}. bevitelnél tart ");
    }
} while (sum <= limit);