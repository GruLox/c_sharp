


public class NationalityWithCount
{
    public string Nationality { get; set; }

    public int Count { get; set; }

    public NationalityWithCount() { }
    public NationalityWithCount(string nationality, int count)
    {
        Nationality = nationality;
        Count = count;
    }
}
