namespace _03_Abstraction;

public abstract class Vehicle
{
    // virtual means that the method can be overridden in a derived class but does not have to be
    public virtual void Horn()
    {
        Console.Beep(1000, 800);
    }

    // abstract means that the method must be overridden in a derived class
    public abstract void Error();
}
