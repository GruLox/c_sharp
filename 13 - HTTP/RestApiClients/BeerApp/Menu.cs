namespace BeerApp;

public static class Menu
{
    public static async Task ShowMainMenu()
    {
        Console.Clear();

        int id = ExtendedConsole.ReadInteger("Enter the beer id: ", 0);

        var beer = await BeerService.GetByIdAsync(id);

        if (beer is null)
        {
            Console.WriteLine("Beer not found.");
            await Task.Delay(3000);

            await ShowMainMenu();
        }
        else
        {
            AppState.SetBeer(beer);
            UpdateOrDelete();
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
        int choice = ExtendedConsole.ReadInteger("Choose an option: ", 2, 1);

        switch (choice)
        {
            case 1:
                Delete();
                break;
            case 2:
                Update();
                break;
        }

        await ShowMainMenu();
    }

    private static async void Delete()
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

    private static async void Update()
    {
        Console.Clear();

        var updatedBeer = GetUpdatedBeerData();

        await BeerService.UpdateAsync(updatedBeer);

        await Task.Delay(3000);
        await ShowMainMenu();
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
}
