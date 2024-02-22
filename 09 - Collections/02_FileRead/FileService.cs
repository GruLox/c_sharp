using _02_FileRead.Enums;

public static class FileService
{
    #region File Read
    public static async Task<List<Book>> ReadBooksFromFileAsync(string fileName)
    {
        var books = new List<Book>();
        Book book = null;

        string path = Path.Combine("source", fileName);

        using FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None, 128);
        using StreamReader sr = new StreamReader(fs, Encoding.UTF7);

        while (!sr.EndOfStream)
        {
            string line = await sr.ReadLineAsync();
            string[] data = line.Split('\t');

            if (data.Length != 11)
            {
                continue;
            }

            book = new Book
            {
                AuthorLastName = data[0],
                AuthorFirstName = data[1],
                BirthDate = DateTime.Parse(data[2]),
                Title = data[3],
                ISBN = data[4],
                Publisher = data[5],
                PublishYear = int.Parse(data[6]),
                Price = int.Parse(data[7]),
                Theme = Book.GetTheme(data[8]),
                PageNumber = int.Parse(data[9]),
                Honorarium = int.Parse(data[10])
            };
            
            books.Add(book);
        }

        return books;
    }
    #endregion

    #region File Write
    public static async Task WriteBooksToFileAsync(string fileName, List<Book> books)
    {
        Directory.CreateDirectory("output");
        string path = Path.Combine("output", fileName);

        using FileStream fs
            = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 128);
        using StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

        foreach (var book in books)
        {
            await sw.WriteLineAsync($"{book.AuthorLastName}\t{book.AuthorFirstName}\t{book.BirthDate}\t{book.Title}\t{book.ISBN}\t{book.Publisher}\t{book.PublishYear}\t{book.Price}\t{book.Theme}\t{book.PageNumber}\t{book.Honorarium}");
        }
    }

    public static async Task WriteBooksToFileByCategories(string fileName, List<BookTitlesByTheme> booksThemesWithTitles)
    {
        Directory.CreateDirectory("output");
        string path = Path.Combine("output", fileName);

        using FileStream fs
            = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 128);
        using StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

        foreach (var theme in booksThemesWithTitles)
        {
            await sw.WriteLineAsync($"{theme.Theme}:");
            foreach (var title in theme.Titles)
            {
                await sw.WriteLineAsync($"- {title}");
            }
        }
    }

    #endregion


}



