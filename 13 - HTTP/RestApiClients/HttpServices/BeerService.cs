
using Models;

namespace BeerApp;

public class BeerService : BaseService
{
    public static async Task<int> GetTotalCountAsync()
    {
        var totalCount = await SendGetRequestAsync<int>("api/beer/get-total-count");
        return totalCount;
    }

    public static async Task<Beer> GetByIdAsync(int id)
    {
        var beer = await SendGetRequestAsync<Beer>("api/beer/get", id);
        return beer;
    }

    public static async Task<List<Beer>> GetAllAsync()
    {
        var beers = await SendGetRequestAsync<List<Beer>>("api/beer/get-all");
        return beers;
    }

    public static async Task<List<Beer>> GetPageAsync(int pageNumber, int itemsPerPage)
    {
        var query = new Dictionary<string, string>
        {
            { "itemsPerPage", itemsPerPage.ToString() }
        };

        var beers = await SendGetRequestAsync<List<Beer>>($"api/beer/get-page", pageNumber, query);
        return beers;
    }

    public static async Task<bool> AddAsync(Beer beer)
    {
        var isSuccess = await SendPostRequestAsync("api/beer/create", beer);

        Console.WriteLine(isSuccess ? "Beer added successfully!" : "Failed to add beer");

        return isSuccess;
    }

    public static async Task<bool> DeleteAsync(int id)
    {
        var isSuccess = await SendDeleteRequestAsync("api/beer/delete", id);

        Console.WriteLine(isSuccess ? "Beer deleted successfully!" : "Failed to delete beer");

        return isSuccess;
    }

    public static async Task UpdateAsync(Beer beer)
    {
        await SendPutRequestAsync("api/beer/update", beer);

        Console.WriteLine("Beer modified successfully!");
    }
}
