int sum = 0;
int inputNumber = 0;

while (sum <= 100)
{
    int numberToAdd;
    Console.Write("Kérem adjon meg egy számot: ");
    string input = Console.ReadLine();
    bool isNumber = int.TryParse(input, out numberToAdd);
    if (isNumber)
    {
        sum += numberToAdd;
        inputNumber++;
        Console.WriteLine($"A jelenlegi összeg: {sum}, {inputNumber}. bevitelnél tart");
    }
    else
    {
        Console.WriteLine("Nem számot adott meg");
    }
}