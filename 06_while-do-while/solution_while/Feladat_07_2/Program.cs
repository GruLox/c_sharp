int firstNumber = 0;
int secondNumber = 0;
int step = 0;
bool isNumber = false;

while (!isNumber)
{
    Console.Write("Kérem adjon meg egy számot: ");
    string input = Console.ReadLine();
    isNumber = int.TryParse(input, out firstNumber);
} 

isNumber = false;
while (!isNumber || firstNumber >= secondNumber)
{
    Console.Write("Kérem adjon meg egy nagyobb számot: ");
    string input = Console.ReadLine();
    isNumber = int.TryParse(input, out secondNumber);
}

isNumber = false;
while (!isNumber || secondNumber - firstNumber <= step)
{
    Console.Write("Kérem adjon meg egy számot: ");
    string input = Console.ReadLine();
    isNumber = int.TryParse(input, out step);
} 

for (int i = secondNumber; i >= firstNumber; i -= step)
{
    Console.WriteLine(i);
}