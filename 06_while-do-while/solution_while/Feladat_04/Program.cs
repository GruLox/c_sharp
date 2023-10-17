int sum = 0;
int inputNumber = 0;

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

}  while (sum <= 100);