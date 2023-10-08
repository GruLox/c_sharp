int sum = 0;
int inputNumber = 0;

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

}  while (sum <= 100);