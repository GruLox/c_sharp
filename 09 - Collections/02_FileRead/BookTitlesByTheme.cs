using _02_FileRead.Enums;

public class BookTitlesByTheme
{
    public Theme Theme { get; set; }
    public List<string> Titles { get; set; }

    public BookTitlesByTheme() { }
    public BookTitlesByTheme(Theme theme, List<string> titles)
    {
        Theme = theme;
        Titles = titles;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{Theme}:");
        foreach (var title in Titles)
        {
            sb.AppendLine($"- {title}");
        }
        return sb.ToString();
    }

}
