const int DAY_COUNT = 7;
const int MEASUREMENT_COUNT = 3;

double[,] measurements = new double[DAY_COUNT, MEASUREMENT_COUNT];

MatrixService.FillMatrixWithRandomNumbers(measurements, 0, 0.5, 2);

//	Írjuk ki a képernyőre a mért adatokat.  Minden egyes számra 4 karakter mezőt foglaljunk le!
PrintMeasurementsToConsole(measurements);

//	A leesett napi átlag csapadékot növekvő sorrendje
double[] dailyAverages = MatrixService.GetRowAverages<double>(measurements);
double[] sortedDailyAverages = dailyAverages.OrderBy(x => x).ToArray();
PrintDailyAveragesToConsole(sortedDailyAverages);

//	Melyik nap esett a legkevesebb és legtöbb csapadék
int minIndex = Array.IndexOf(dailyAverages, sortedDailyAverages.First());
Console.WriteLine($"A legkevesebb csapadék a(z) {minIndex + 1}. napon esett.");

int maxIndex = Array.IndexOf(dailyAverages, sortedDailyAverages.Last());
Console.WriteLine($"A legtöbb csapadék a(z) {maxIndex + 1}. napon esett.");

//	Melyik nap reggelére esett a legtöbb csapadék
double[] morningMeasurements = MatrixService.GetElementsFromColumn<double>(measurements, 0);
int maxMorningIndex = Array.IndexOf(morningMeasurements, morningMeasurements.Max());
Console.WriteLine($"A legtöbb csapadék reggel a(z) {maxMorningIndex + 1}. napon esett.");

//	Melyik nap esett a legtöbb csapadék reggel 6 és este 22 óraközt
double[] afternoonMeasurements = MatrixService.GetElementsFromColumn<double>(measurements, 1);
double[] eveningMeasurements = MatrixService.GetElementsFromColumn<double>(measurements, 2);
double[] rainMeasuredDuringTheDay = AddArraysTogetherElementByElement(afternoonMeasurements, eveningMeasurements);
int maxRainMeasuredDuringTheDayIndex = Array.IndexOf(rainMeasuredDuringTheDay, rainMeasuredDuringTheDay.Max());
Console.WriteLine($"A legtöbb csapadék reggel 6 és este 22 óra között a(z) {maxRainMeasuredDuringTheDayIndex + 1}. napon esett.");

static void PrintMeasurementsToConsole(double[,] measurements)
{
    Console.WriteLine("Mért adatok:");
    Console.WriteLine("".PadRight(8) + "Reggel".PadRight(8) + "Délután".PadRight(8) + "Este".PadRight(8));
    for (int i = 0; i < measurements.GetLength(0); i++)
    {
        Console.Write($"Nap {i + 1}".PadRight(8));
        for (int j = 0; j < measurements.GetLength(1); j++)
        {
            Console.Write(measurements[i, j].ToString("F2").PadRight(8));
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

static void PrintDailyAveragesToConsole(double[] measurements)
{
    Console.WriteLine("Napi átlagok:");
    for (int i = 0; i < measurements.Length; i++)
    {
        Console.WriteLine($"Nap {i + 1}: {measurements[i]:F2}");
    }
    Console.WriteLine();
}

static double[] AddArraysTogetherElementByElement(double[] array1, double[] array2)
{
    double[] result = new double[array1.Length];
    for (int i = 0; i < array1.Length; i++)
    {
        result[i] = array1[i] + array2[i];
    }
    return result;
}
