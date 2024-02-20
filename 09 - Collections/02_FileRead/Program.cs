using _02_FileRead.Enums;

var books = await FileService.ReadBooksFromFileAsync("adatok.txt");

//Írjuk ki a képernyőre az össz adatot
books.WriteCollectionToConsole<Book>();


//Keressük ki az informatika témajú könyveket és mentsük el őket az informatika.txt állömányba
var itBooks = books.Where(b => b.Theme == Theme.Informatika).ToList();
await FileService.WriteBooksToFileAsync("informatika.txt", itBooks);


//Az 1900.txt állományba mentsük el azokat a könyveket amelyek az 1900-as években íródtak
var booksWrittenInThe1900s = books.Where(b => b.PublishYear >= 1900 && b.PublishYear < 2000).ToList();
await FileService.WriteBooksToFileAsync("1900.txt", booksWrittenInThe1900s);

//Rendezzük az adatokat a könyvek oldalainak száma szerint csökkenő sorrendbe és a sorbarakott.txt állományba mentsük el.
var booksOrderedByPageNumber = books.OrderByDescending(b => b.PageNumber).ToList();
await FileService.WriteBooksToFileAsync("sorbarakott.txt", booksOrderedByPageNumber);


//„kategoriak.txt” állományba mentse el a könyveket téma szerint. Például:
//Thriller:
//-könnyv1
//- könnyv2
//Krimi:
//-könnyv1
//- könnyv2
var booksByTheme = books.GroupBy(b => b.Theme).Select(g => new BookTitlesByTheme
                                                {
                                                    Theme = g.Key,
                                                    Titles = g.Select(b => b.Title).ToList()
                                                }).ToList();

await FileService.WriteBooksToFileByCategories("kategoriak.txt", booksByTheme);
