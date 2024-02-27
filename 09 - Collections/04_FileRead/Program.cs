var gamblers = await FileService.ReadLotteryTipsFromFileAsync("adatok.txt");

//-Írjuk ki a képernyőre az össz adatot
gamblers.WriteCollectionToConsole<Gambler>();

//- Random számok segítségével generáljuk le a napi 7 nyerő számot és írjuk őket egy szöveges állományba 
//  melynek az aktuális nap lesz a neve
List<int> winningNumbers = GenerateWinningNumbers(7);
string winningNumbersFileName = $"nyeroszamok-{DateTime.Now:yyyyMMdd}.txt";
await FileService.WriteWinningNumbersToFileAsync(winningNumbersFileName, winningNumbers);


//- Keressük ki, van(ak)-e 7 találatos szelvény(ek), ha igen írjuk ki a nyertesek nevét a nyertesek-{mai dátum}.txt állományba.
var winners = gamblers.Where(t => t.Tips.Intersect(winningNumbers).Count() == 7);
string winnersFileName = $"nyertesek-{DateTime.Now:yyyyMMdd}.txt";
await FileService.WriteCollectionToFileAsync(winnersFileName, winners);


//-Keressük ki, hogy a befizetett játékosok hány találatot értek el, és mentsük el a talalatok-{mai dátum}.txt
//állományba a játékos nevét és a találatainak számát
var hitCounts = gamblers.Select(t => new GamblerWithHitCount 
{ 
    Name = t.Name, 
    Tips = t.Tips, 
    HitCount = t.Tips.Intersect(winningNumbers).Count() 
});
string hitCountsFileName = $"talalatok-{DateTime.Now:yyyyMMdd}.txt";
await FileService.WriteCollectionToFileAsync(hitCountsFileName, hitCounts);



static List<int> GenerateWinningNumbers(int count)
{
    var winningNumbers = new List<int>();
    var random = new Random();

    while (winningNumbers.Count < count)
    {
        int number = random.Next(1, 46);

        if (!winningNumbers.Contains(number))
        {
            winningNumbers.Add(number);
        }
    }

    return winningNumbers;
}