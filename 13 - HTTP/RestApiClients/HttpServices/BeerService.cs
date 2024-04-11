
using Models;

namespace BeerApp;

public class BeerService: BaseService
{
    public static async Task<Beer> GetByIdAsync(int id)
    {
        var beer = await SendGetRequestAsync<Beer>("api/beer/get", id);
        return beer;
    }

    public static async Task<bool> DeleteAsync(int id)
    {
        return await SendDeleteRequestAsync("api/beer/delete", id);
    }

    public static async Task UpdateAsync(Beer beer)
    {
        await SendPutRequestAsync("api/beer/update", beer);

        Console.WriteLine("Sikerült a módosítás");
    }
    

}
