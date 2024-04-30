public class FighterJet : Airplane
{
    private int _missiles = 0;

    public FighterJet(string model, string type, int maxSpeed) : base(model, type, maxSpeed)
    {
        _missiles = _random.Next(1, 10);
    }
    
    public override void Attack()
    {
        if (_missiles > 0)
        {
            Console.WriteLine($"Firing missile!");
            _missiles--;
        }
        else
        {
            Console.WriteLine("No missiles left!");
        }
    }
}
