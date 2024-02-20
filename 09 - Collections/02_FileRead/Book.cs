//A konyvek.txt állományban az adatok a következő módón vannak tárolva:

//Vezetéknév(íróé),
//Keresztnév(íróé),
//SzületésiDátum,
//Cím,
//ISBN,
//Kiadó,
//KiadvasiÉv,
//ár,
//Téma,
//Oldalszám,
//Honorárium (amit a könyvért kapott az író)

using _02_FileRead.Enums;

public class Book
{
    public string AuthorLastName { get; set; }
    public string AuthorFirstName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Title { get; set; }
    public string ISBN { get; set; }
    public string Publisher { get; set; }
    public int PublishYear { get; set; }
    public int Price { get; set; }
    public Theme Theme { get; set; }
    public int PageNumber { get; set; }
    public int Honorarium { get; set; }

    public Book()
    {
    }
    public Book(string authorLastName, string authorFirstName, DateTime birthDate, string title, string isbn, string publisher, int publishYear, int price, string theme, int pageNumber, int honorarium)
    {
        AuthorLastName = authorLastName;
        AuthorFirstName = authorFirstName;
        BirthDate = birthDate;
        Title = title;
        ISBN = isbn;
        Publisher = publisher;
        PublishYear = publishYear;
        Price = price;
        Theme = GetTheme(theme);
        PageNumber = pageNumber;
        Honorarium = honorarium;
    }


    public override string ToString()
    {
        return $"{AuthorLastName} {AuthorFirstName} - {Title} ({PublishYear})";
    }

    public static Theme GetTheme(string theme)
    {
        // parse theme, ignore case, default theme is Egyeb
        string themeWithoutAccents = Helpers.ToEnglishAlphabetCharacters(theme);
        return Enum.TryParse<Theme>(themeWithoutAccents, true, out Theme result) ? result : Theme.Egyeb;
    }
}
