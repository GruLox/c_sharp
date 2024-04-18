namespace _03_Abstraction;

public class Truck : Vehicle
{
    public override void Horn()
    {
        Console.Beep(500, 800);
    }
    public override void Error()
    {
        for (int i = 0; i < 3; i++)
        {
            Console.Beep(800, 500);
            Thread.Sleep(200);
        }
    }
}
