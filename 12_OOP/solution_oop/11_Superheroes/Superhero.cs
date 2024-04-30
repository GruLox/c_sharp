public abstract class Superhero : ISuperhero
{
    public string Name { get; protected set; }

    public int Power { get; private set; } = new Random().Next(1, 100);

    public bool Fights(ISuperhero enemy)
    {
        return this.Power > enemy.Power;
    }
}
