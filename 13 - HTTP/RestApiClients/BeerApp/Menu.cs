namespace BeerApp;

public static class Menu
{
    public static async Task DisplayMainMenu()
    {
        Console.Clear();

        Console.WriteLine("1 - Add a new beer");
        Console.WriteLine("2 - Modify a beer");
        Console.WriteLine("3 - List all beers");
        Console.WriteLine("4 - Exit");

        int choice = ExtendedConsole.ReadInteger("Choose an option: ", 4, 1);

        switch (choice)
        {
            case 1:
                await DisplayAddMenu();
                break;
            case 2:
                await GetBeerToModify();
                break;
            case 3:
                await DisplayBeersPaginated();
                break;
            case 4:
                Environment.Exit(0);
                break;
        }

        await DisplayMainMenu();
    }
    public static async Task DisplayAddMenu()
    {
        Console.Clear();

        var beer = GetNewBeerData();

        await BeerService.AddAsync(beer);

        await Task.Delay(3000);

        await DisplayMainMenu();
    }

    public static async Task DisplayBeersPaginated()
    {
        int page = 1;
        int itemsPerPage = 5;
        int totalCount = await BeerService.GetTotalCountAsync();
        int totalPages = (int)Math.Ceiling((double)totalCount / itemsPerPage);

        while (true)
        {
            await DisplayPageOfBeers(page, itemsPerPage);

            Console.WriteLine($"\nPage {page} of {totalPages}");
            Console.WriteLine("1. Next page");
            Console.WriteLine("2. Previous page");
            Console.WriteLine("3. Change number of items per page");
            Console.WriteLine("4. Exit");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    if (page < totalPages) page++;
                    break;
                case "2":
                    if (page > 1) page--;
                    break;
                case "3":
                    itemsPerPage = ExtendedConsole.ReadInteger("Enter the number of items per page: ", min: 1);
                    totalPages = (int)Math.Ceiling((double)totalCount / itemsPerPage);
                    if (page > totalPages) page = totalPages;
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    public static async Task DisplayPageOfBeers(int page, int numberOfItems)
    {
        var beers = await BeerService.GetPageAsync(page, numberOfItems);

        Console.Clear();

        beers.WriteCollectionToConsole();
    }

    public static async Task GetBeerToModify()
    {
        Console.Clear();

        int id = ExtendedConsole.ReadInteger("Enter the beer id: ", 0);

        var beer = await BeerService.GetByIdAsync(id);

        if (beer is null)
        {
            Console.WriteLine("Beer not found.");
            await Task.Delay(3000);

            await GetBeerToModify();
        }
        else
        {
            AppState.SetBeer(beer);
            await UpdateOrDelete();
        }


    }

    public static async Task UpdateOrDelete()
    {
        Console.Clear();

        var beer = AppState.GetBeer();
        beer.WriteToConsole();

        Console.WriteLine();

        Console.WriteLine("1 - Delete");
        Console.WriteLine("2 - Update");
        Console.WriteLine("3 - Back");
        int choice = ExtendedConsole.ReadInteger("Choose an option: ", min: 1, max: 3);

        switch (choice)
        {
            case 1:
                await Delete();
                break;
            case 2:
                await Update();
                break;
            case 3:
                await DisplayMainMenu();
                break;
        }

        await DisplayMainMenu();
    }

    private static async Task Delete()
    {
        char answer = ExtendedConsole.ReadChar("Are you sure you want to delete this beer? (y/n): ", ['y', 'Y', 'n', 'N']);

        if (answer == 'n' || answer == 'N')
        {
            return;
        }

        var beer = AppState.GetBeer();
        bool isSuccess = await BeerService.DeleteAsync(beer.Id);

        AppState.Clear();

        Console.WriteLine(isSuccess ? "Beer deleted successfully!" : "An error occurred while deleting the beer.");

        await Task.Delay(3000);
    }

    private static async Task Update()
    {
        Console.Clear();

        var updatedBeer = GetUpdatedBeerData();

        await BeerService.UpdateAsync(updatedBeer);

        await Task.Delay(3000);
        await GetBeerToModify();
    }

    private static Beer GetUpdatedBeerData()
    {
        Console.Clear();

        var beer = new Beer();

        Console.WriteLine("Leave empty to keep the current value.");

        Console.Write("Enter the beer name: ");
        beer.Name = Console.ReadLine();

        double price = ExtendedConsole.ReadDouble("Enter the beer price: ", min: 0, max: int.MaxValue);
        beer.Price = $"${Math.Abs(price)}";

        Console.Write("Enter the beer image: ");
        beer.Image = Console.ReadLine();

        AppState.Update(beer);

        return AppState.GetBeer();
    }

    private static Beer GetNewBeerData()
    {
        Console.Clear();

        var beer = new Beer();

        beer.Name = ExtendedConsole.ReadString("Enter the beer name: ");

        double price = ExtendedConsole.ReadDouble("Enter the beer price: ", min: 0, max: int.MaxValue);
        beer.Price = $"${Math.Abs(price)}";

        beer.Image = ExtendedConsole.ReadString("Enter the beer image: ");

        beer.Rating = GetNewRating();

        return beer;
    }

    private static Rating GetNewRating()
    {
        Console.Clear();

        var rating = new Rating();

        rating.Average = ExtendedConsole.ReadDouble("Enter the beer rating average: ", min: 0, max: 5);
        rating.Reviews = ExtendedConsole.ReadInteger("Enter the beer rating reviews: ", min: 0);

        return rating;
    }
}
