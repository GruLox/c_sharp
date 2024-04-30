public class BomberJet : Airplane
{
    private int _bombs = 0;

    public BomberJet(string model, string type, int maxSpeed) : base(model, type, maxSpeed)
    {
        _bombs = _random.Next(1, 10);
    }

    public override void Attack()
    {
        // drop a random number of bombs and decrement the number of bombs left
        if (_bombs > 0)
        {
            var bombsDropped = _random.Next(1, _bombs + 1);
            Console.WriteLine($"Dropping {bombsDropped} bombs!");
            _bombs -= bombsDropped;
        }
        else
        {
            Console.WriteLine("No bombs left!");
        }

    }
}
