public class VolleyballerWithDifferenceFromAverage: Volleyballer
{
    public double DifferenceFromAverage { get; set; }
    public VolleyballerWithDifferenceFromAverage(Volleyballer volleyballer, double averageHeight)
    {
        Name = volleyballer.Name;
        Height = volleyballer.Height;
        Position = volleyballer.Position;
        Nationality = volleyballer.Nationality;
        Team = volleyballer.Team;
        Country = volleyballer.Country;
        DifferenceFromAverage = Math.Round(volleyballer.Height - averageHeight, 2);
    }
}
