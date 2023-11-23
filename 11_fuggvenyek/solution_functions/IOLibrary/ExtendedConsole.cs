﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOLibrary;

public static class ExtendedConsole
{
    public static int ReadInteger(string prompt)
    {
        bool isNumber;
        int number;

        do
        {
            Console.Write(prompt);
            string text = Console.ReadLine();
            isNumber = int.TryParse(text, out number);
        } while (!isNumber);

        return number;
    }

    public static int ReadInteger(string prompt, int max)
    {
        bool isNumber;
        int number;

        do
        {
            Console.Write(prompt);
            string text = Console.ReadLine();
            isNumber = int.TryParse(text, out number);

            if (number > max)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"A megadott szám nem lehet nagyobb mint {max}");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("A folytatáshoz nyomja meg bármely gombot.");

                Console.ReadKey();

                Console.ResetColor();
            }
        } while (!isNumber || number >= max);

        return number;
    }

    public static int ReadInteger(string prompt, int max, int min)
    {
        bool isNumber;
        int number;

        do
        {
            Console.Write(prompt);
            string text = Console.ReadLine();
            isNumber = int.TryParse(text, out number);

            if (number > max)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"A megadott szám nem lehet nagyobb mint {max}");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("A folytatáshoz nyomja meg bármely gombot.");

                Console.ReadKey();

                Console.ResetColor();
            }
            else if (number < min)
            {
                if (number > max)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"A megadott szám nem lehet kisebb mint {min}");

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("A folytatáshoz nyomja meg bármely gombot.");

                    Console.ReadKey();

                    Console.ResetColor();
                }
            }
        } while (!isNumber ||  number <= min || number >= max);

        return number;
    }

    public static double ReadDouble(string prompt)
    {
        bool isNumber;
        double number;

        do
        {
            Console.Write(prompt);
            string text = Console.ReadLine();
            isNumber = double.TryParse(text, new CultureInfo("en-EN") , out number);
        } while (!isNumber);

        return number;
    }

    public static string ReadString(string prompt)
    {
        string text = string.Empty;
        do
        {
            Console.Write(prompt);
            text = Console.ReadLine().Trim();
        }
        while (string.IsNullOrWhiteSpace(text));

        return text;
    }

}
