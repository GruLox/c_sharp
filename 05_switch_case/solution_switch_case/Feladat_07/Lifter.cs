class Lifter
{

    public string Name { get; set; }
    public int Age { get; set; }
    public double BodyWeight { get; set; }
    public double BenchPressMax { get; set; }

    public double RelativeStrength => BenchPressMax / BodyWeight;

    public Lifter()
    {       
    }

    public Lifter(string name, int age, double bodyWeight, double benchPressMax)
    {
        Name = name;
        Age = age;
        BodyWeight = bodyWeight;
        BenchPressMax = benchPressMax;
    }

    public override string ToString()
    {
        return $"{Name} ({Age}) - {BodyWeight} KG BW - {BenchPressMax} KG Bench Press Max";
    }  
    
    public string StrengthTier()
    {
        string strengthTier = RelativeStrength switch
        {
            > 1 => "Isten",
            > 0.6 => "Profi",
            > 0.4 => "Haladó",
            > 0.2 => "Kezdő"
        };

        return strengthTier;
    }
}

