public abstract class Avenger(double superPower, bool hasWeakness) : ISuperhero
{
    protected double superPower = superPower;
    protected bool hasWeakness = hasWeakness;

    public abstract bool SaveTheWorld();

    public double GetPower()
    {
        return superPower;
    }

    public virtual bool DoesDefeat(ISuperhero superhero)
    {
        if (superhero is Avenger avenger)
        {
            if (avenger.hasWeakness && avenger.superPower < superPower)
            {
                if (superhero is Batman batman)
                {
                    if (superPower > batman.GetPower() * 2)
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }
        }
        return false;
    }

    public override string ToString()
    {
        return $"SuperPower: {superPower}, HasWeakness: {hasWeakness}";
    }

    
}

