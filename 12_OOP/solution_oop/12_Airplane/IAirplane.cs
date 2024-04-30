public interface IAirplane
{
    public string Model { get; }

    public string Type { get; }

    public int MaxSpeed { get; }

    void Attack();
}
