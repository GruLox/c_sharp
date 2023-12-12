const int N = 10;

int[] array = Get3DigitIntArray(N);


static int[] Get3DigitIntArray(int length)
{
    Random rnd = new Random();
    int[] result = new int[length];
    for (int i = 0; i < length; i++)
    {
        result[i] = rnd.Next(100, 1000);
    }

    return result;
}