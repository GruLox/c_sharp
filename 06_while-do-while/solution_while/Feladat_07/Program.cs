int firstNumber =;
int secondNumber;

do
{
    Console.Write("Kérem adjon meg egy számot: ");
    string input = Console.ReadLine();
    int.TryParse(input, out firstNumber);
    Console.WriteLine("Kérem adjon meg egy nagyobb számot: ");
    input = Console.ReadLine();
    int.TryParse(input, out secondNumber);
}