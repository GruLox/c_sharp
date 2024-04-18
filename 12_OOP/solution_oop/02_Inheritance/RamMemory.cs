namespace _02_Inheritance;

public class RamMemory : Hardware
{
    public int Capacity { get; set; }

    public int Frequency { get; set; }

    public RamMemory() : base()
    {
    }

    public RamMemory(int capacity, int frequency, string manufacturer, string model, string type)
        : base(manufacturer, model, type)
    {
        Capacity = capacity;
        Frequency = frequency;
    }
}
