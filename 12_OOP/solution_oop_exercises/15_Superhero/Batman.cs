public class Batman : Avenger, IBillionaire
{
    private double ingenuity = 100;
    public Batman() : base(200, false)
    {
    }

    public void MakeGadget()
    {
        ingenuity += 50;
    }

    public override bool SaveTheWorld()
    {
        return superPower > 1000;
    }

    public override string ToString()
    {
        return $"SuperPower: {superPower}, HasWeakness: {hasWeakness}, Batman";
    }

    public override bool DoesDefeat(ISuperhero superhero)
    {
        if (superhero is Avenger avenger)
        {
            if (avenger.GetPower() < ingenuity * 2)
            {
                return true;
            }
        }
        return false;
        
    }
}
