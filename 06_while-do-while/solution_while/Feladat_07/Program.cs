int firstNumber = 0;
int secondNumber = 0;
int step = 0;
bool isNumber = false;

do
{
    Console.Write("Kérem adjon meg egy számot: ");
    string input = Console.ReadLine();
    isNumber = int.TryParse(input, out firstNumber);
} while (!isNumber);

isNumber = false;
do
{
    Console.Write("Kérem adjon meg egy nagyobb számot: ");
    string input = Console.ReadLine();
    isNumber = int.TryParse(input, out secondNumber);
} while (!isNumber || firstNumber >= secondNumber);


isNumber = false;
do
{
    Console.Write("Kérem adjon meg egy számot: ");
    string input = Console.ReadLine();
    isNumber = int.TryParse(input, out step);
} while (!isNumber || secondNumber - firstNumber <= step);



for (int i = secondNumber; i >= firstNumber; i -= step)
{
    Console.WriteLine(i);
}