namespace CustomLibrary;

public static partial class MathFunctions
{
    public static double CelsiusToKelvin(double celsius) => celsius + 273.15;

    public static double CelsiusToFahrenheit(double celsius) => 9 / 5 * celsius + 32;

    public static double PythegoreanTheorem(double x, double y) => Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
}
