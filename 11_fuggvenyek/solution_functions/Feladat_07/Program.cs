int[] arr1 = [];
int[] arr2 = [];

arr1 = FillWithRandints(arr1, 10);
arr2 = FillWithRandints(arr2, 10);

Console.WriteLine($"Az első tömb értékei: {string.Join(',', arr1)}");
Console.WriteLine($"A második tömb értékei: {string.Join(',', arr2)}");

string arrWithLargerSum = arr1.Sum(x => x) > arr2.Sum(x => x) ? "első" : "második";

Console.WriteLine($"A/Az {arrWithLargerSum} tömb számainak összege a nagyobb.");

int[] FillWithRandints(int[] arr, int n)
{
    Random random = new Random();
    for (int i = 0; i < n; i++)
    {
        arr = arr.Append(random.Next(100)).ToArray();
    }
    return arr;
}

