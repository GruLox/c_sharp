﻿int age = 0;
bool isNumber = false;

do
{
    Console.Write("Kérem adjon meg egy életkort: ");
    string input = Console.ReadLine();
    isNumber = int.TryParse(input, out age);

} while (!isNumber || age < 0 || age > 99);

string ageTier = age switch
{
    >= 0 and <= 6 => "gyerek",
    >= 7 and <= 18 => "iskolás",
    >= 19 and <= 65 => "dolgozó",
    > 65 => "nyugdíjas",
};

Console.WriteLine(ageTier);