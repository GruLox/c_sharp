public class GamblerWithHitCount : Gambler
{
    public int HitCount { get; set; }
    public GamblerWithHitCount() { }
    public GamblerWithHitCount(string gambler, ICollection<int> tips, int hitCount) : base(gambler, tips)
    {
        HitCount = hitCount;
    }

    public override string ToString()
    {
        return $"{Name} - {string.Join(", ", Tips)} - {HitCount}";
    }
}
