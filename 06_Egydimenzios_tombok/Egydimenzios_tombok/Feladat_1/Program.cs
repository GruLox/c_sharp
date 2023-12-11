Random rnd = new Random();

int[] array = await GetIntArrayAsync(10); // bevárjuk, hogy a függvény lefusson
Console.WriteLine("Generated array: ");
ReversePrintArrayToConsole(array);

int sum = GetArraySum(array);
Console.WriteLine($"Sum of the array: {sum}");

double avarage = (double)sum / array.Length;
Console.WriteLine($"Avarage of the array: {avarage:F2}");

Console.WriteLine("Even elements of the array: ");
int[] evenNumbers = GetEvenNumbersFromArray(array);
PrintArrayToConsole(evenNumbers);

int numberOfTwoDigitNumbers = GetTwoDigitNumbers(array);
Console.WriteLine($"Number of numbers greater than 9 in the array: {numberOfTwoDigitNumbers}");

Console.WriteLine("Single digit elements of the array: ");
int[] singleDigitElementsOfTheArray = array.Where(x => x < 10).ToArray();
PrintArrayToConsole(singleDigitElementsOfTheArray);

int oddnumbersSum = CalculateOddNumbersSumOfArray(array); // array.Where(x => x % 2 == 1).Sum(x => x)
Console.WriteLine($"\nOdd numbers sum: {oddnumbersSum}");

int zeroEndedNumbers = array.Count(x => x % 10 == 0);
Console.WriteLine($"\nZero ended numbers: {zeroEndedNumbers}");

Console.WriteLine("\nThe array's elements in ascending order: ");
OrderedArrayAscending(array);
PrintArrayToConsole(array);

Console.ReadKey();
// async - aszinkron függvény (a függvény lefutása bevárható, mivel nem fejeződik be rögtön)
// Task<int[]> - az aszinkron függvény eredménye egy feladat (Task) amelynek az eredménye egy int tipusú tömb lesz amikor befejeződik 
async Task<int[]> GetIntArrayAsync(int arraySize)
{
    int[] array = new int[arraySize];

    for(int i = 0; i < arraySize; i++)
    {
        array[i] = rnd.Next(0, 100);
        await Task.Delay(100);
    }

    return array;
}

void ReversePrintArrayToConsole(int[] arrayToPrint)
{
    for (int i = arrayToPrint.Length - 1; i >= 0; i--)
    {
        Console.WriteLine($"[{i + 1}] = {arrayToPrint[i]}");
    }
}

void PrintArrayToConsole(int[] arrayToPrint)
{
    for (int i = 0; i < arrayToPrint.Length; i++)
    {
        Console.WriteLine($"[{i + 1}] = {arrayToPrint[i]}");
    }
}

int GetArraySum(int[] array)
{
    int sum = 0;

    foreach (int item in array)
    {
        sum += item;
    }

    return sum;
}

int[] GetEvenNumbersFromArray(int[] array)
{
    int[] evenNumbers = array.Where(x => x % 2 == 0)
                             .ToArray();

    return evenNumbers;
}

//int GetTwoDigitNumbers(int[] array) => array.Count(x => x > 9) 
int GetTwoDigitNumbers(int[] array)
{
    int counter = 0;

    foreach(int number in array)
    {
        if (number > 9)
            counter++;
    }

    return counter;
}

int CalculateOddNumbersSumOfArray(int[] array)
{
    int sum = 0;

    foreach(int number in array)
    {
        if(number % 2 == 1)
        {
            sum += number;
        }
    }

    return sum;
}

void OrderedArrayAscending(int[] array)
{
    int temp = 0;

    for(int i = 0; i < array.Length - 1; i++)
    {
        for(int j = i + 1; j < array.Length; j++)
        {
            if (array[j] < array[i])
            {
                temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }
    }
}