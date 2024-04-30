public interface ISuperhero
{
    string Name { get; }

    int Power { get; }

    bool Fights(ISuperhero enemy);
    
}
