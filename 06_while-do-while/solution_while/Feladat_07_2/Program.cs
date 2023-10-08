int firstNumber = 0;
int secondNumber = 0;
int step = 0;

while (!(secondNumber > firstNumber) || secondNumber - firstNumber <= step)
{
    Console.Write("Kérem adjon meg egy számot: ");
    string input = Console.ReadLine();
    int.TryParse(input, out firstNumber);
    Console.Write("Kérem adjon meg egy nagyobb számot: ");
    input = Console.ReadLine();
    int.TryParse(input, out secondNumber);
    Console.Write("Kérem adjon meg egy lépésközt, amely kisebb mint a két szám különbsége: ");
    input = Console.ReadLine();
    int.TryParse(input, out step);
}

for (int i = secondNumber; i >= firstNumber; i -= step)
{
    Console.WriteLine(i);
}