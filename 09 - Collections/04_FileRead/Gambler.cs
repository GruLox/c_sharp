public class Gambler
{
    public string Name { get; set; }

    public ICollection<int> Tips { get; set; }

    public Gambler() { }

    public Gambler(string name, ICollection<int> tips)
    {
        Name = name;
        Tips = tips;
    }

    public override string ToString()
    {
        return $"{Name} - {string.Join(", ", Tips)}";
    }
}
