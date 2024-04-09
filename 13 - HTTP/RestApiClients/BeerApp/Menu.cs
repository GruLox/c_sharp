namespace BeerApp;

public static class Menu
{
    public static async void ShowMainMenu()
    {
        int id = ExtendedConsole.ReadInteger("Enter the beer id: ", 0);

        var beer = await BeerService.GetByIdAsync(id);

        beer.WriteToConsole();


    }

}
