﻿int evenNumber = 0;
int oddNumber = 0;

do
{
    Console.Write("Kérem adjon meg egy páros számot: ");
    string input = Console.ReadLine();
    int.TryParse(input, out evenNumber);

    Console.Write("Kérem adjon meg egy nagyobb páratlan számot: ");
    input = Console.ReadLine();
    int.TryParse(input, out oddNumber);

} while (evenNumber % 2 != 0 || oddNumber % 2 != 1 || oddNumber <= evenNumber);

Random random = new Random();
int randomNumber = random.Next(evenNumber, oddNumber + 1);
Console.WriteLine($"random szám: {randomNumber}");

int furtherNumber = 
    randomNumber - evenNumber < oddNumber - randomNumber ? oddNumber : evenNumber;

double average = (double)(evenNumber + oddNumber) / 2;

int countOfDivisibleBy4 = 0;
for (int i = evenNumber; i < oddNumber + 1; i++)
{
    if (i % 4 == 0) countOfDivisibleBy4++;
}

Console.WriteLine($"{furtherNumber} van messzebb a randomszámtól");
Console.WriteLine($"A két érték közti átlag: {average}");
Console.WriteLine($"A 4-gyel osztható számok száma a két érték között: {countOfDivisibleBy4}");