namespace _03_Abstraction;

public class Car : Vehicle
{
    public override void Error()
    {
        for (int i = 0; i < 2; i++)
        {
            Console.Beep(400, 300);
            Thread.Sleep(200);
        }
    }
}
