public class PositionWithHeightSum
{
    public string Position { get; set; }

    public int HeightSum { get; set; }

    public PositionWithHeightSum()
    {
    }
    public PositionWithHeightSum(string position, int heightSum)
    {
        Position = position;
        HeightSum = heightSum;
    }

    public override string ToString()
    {
        return $"{Position}: {HeightSum}";
    }

}
