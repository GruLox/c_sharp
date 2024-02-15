namespace Custom.Library.MathExtensions;


public static partial class MathFunctions
{
    public static double CelsiusToKelvin(double celsius) => celsius + 273.15;

    public static double CelsiusToFarenheit(double celsius) => (9 / 5 * celsius) + 32;

    public static double PythegoreanTheorem(double x, double y) => Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));

    public static double BMIIndex(double weight, double height) => weight / (height * height);
}







