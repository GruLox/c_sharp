public abstract class Airplane(string model, string type, int maxSpeed) : IAirplane
{
    protected readonly Random _random = new();

    public string Model { get; } = model;

    public string Type { get; } = type;

    public int MaxSpeed { get; } = maxSpeed;

    public abstract void Attack();
}
