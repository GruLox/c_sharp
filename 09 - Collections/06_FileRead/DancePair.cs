public class DancePair
{
    public int Id { get; set; }
    public string MaleDancer { get; set; }

    public string FemaleDancer { get; set; }

    public string Dance { get; set; }

    public DancePair() { }

    public DancePair(int id, string maleDancer, string femaleDancer, string dance)
    {
        Id = id;
        MaleDancer = maleDancer;
        FemaleDancer = femaleDancer;
        Dance = dance;
    }
}
