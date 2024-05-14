public static class PastryFactory
{
    public static IPrice GetPastryProduct(string[] parts)
    {
        return parts[0] switch
        {
            "Pogacsa" => new Scone(double.Parse(parts[1]), double.Parse(parts[2])),
            "Kave" => new Coffee(parts[1] == "habos"),
            _ => throw new ArgumentException("Unknown pastry type")
        };
    }

}
