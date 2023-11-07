using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOLibrary;

public static class ExtendedConsole
{
    public static int ReadInteger()
    {
        bool isNumber;
        int number;

        do
        {
            string text = Console.ReadLine();
            isNumber = int.TryParse(text, out number);
        } while (!isNumber);

        return number;
    }

    public static double ReadDouble()
    {
        bool isNumber;
        double number;

        do
        {
            string text = Console.ReadLine();
            isNumber = double.TryParse(text, new CultureInfo("en-EN") , out number);
        } while (!isNumber);

        return number;
    }

}
