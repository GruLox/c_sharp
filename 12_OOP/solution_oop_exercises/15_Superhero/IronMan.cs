public class IronMan : Avenger, IBillionaire
{
    private readonly Random _random = new();
    public IronMan() : base(150, true)
    {
    }

    public void MakeGadget()
    {
        superPower += _random.Next(0, 11);
    }

    public override bool SaveTheWorld()
    {
        return superPower > 1000;
    }

    public override string ToString()
    {
        return $"SuperPower: {superPower}, HasWeakness: {hasWeakness}, IronMan";
    }
}
