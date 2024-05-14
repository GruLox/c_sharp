public class Coffee(bool isCreamy) : IPrice
{
    private bool IsCreamy { get; set; } = isCreamy;
    private const double CUP_OF_COFFEE = 180;

    public double Cost()
    {
        return IsCreamy ? CUP_OF_COFFEE * 1.5 : CUP_OF_COFFEE;
    }

    public override string ToString()
    {
        return $"Kávé: {(IsCreamy ? "Habos" : "Nem habos")} - {Cost()} Ft";
    }
}